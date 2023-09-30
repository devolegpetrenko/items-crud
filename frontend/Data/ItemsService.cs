using frontend.Exceptions;
using ItemsCrud.Models;
using Newtonsoft.Json;
using System.Text;

namespace frontend.Data;

public class ItemsService : IItemsService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ItemsService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<ItemListingModel>> GetAllItems()
    {
        var httpClient = _httpClientFactory.CreateClient("backend");

        var response = await httpClient.GetAsync("/api/items");

        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(responseContent);
        }

        return JsonConvert.DeserializeObject<List<ItemListingModel>>(responseContent);
    }

    public async Task<ItemViewModel> GetItem(Guid id)
    {
        var httpClient = _httpClientFactory.CreateClient("backend");

        var response = await httpClient.GetAsync($"/api/items/{id}");

        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(responseContent);
        }

        return JsonConvert.DeserializeObject<ItemViewModel>(responseContent);
    }

    public class ErrorMessageContent
    {
        public Dictionary<string, string[]> Errors { get; set; }
    }

    public async Task<Guid> AddItem(ItemViewModel item)
    {
        var httpClient = _httpClientFactory.CreateClient("backend");

        var json = JsonConvert.SerializeObject(item);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PostAsync("/api/items", content);

        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var errorContent = JsonConvert.DeserializeObject<ErrorMessageContent>(responseContent);

            throw CreateValidationException(errorContent);
        }

        return JsonConvert.DeserializeObject<Guid>(responseContent);
    }

    ValidationException CreateValidationException(ErrorMessageContent errorContent)
    {
        return new ValidationException(errorContent.Errors.SelectMany(x => x.Value).ToArray());
    }

    public async Task UpdateItem(Guid id, ItemViewModel item)
    {
        var httpClient = _httpClientFactory.CreateClient("backend");

        var json = JsonConvert.SerializeObject(item);

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await httpClient.PutAsync($"/api/items/{id}", content);

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            var errorContent = JsonConvert.DeserializeObject<ErrorMessageContent>(responseContent);

            throw CreateValidationException(errorContent);
        }
    }

    public async Task RemoveItem(Guid id)
    {
        var httpClient = _httpClientFactory.CreateClient("backend");

        var response = await httpClient.DeleteAsync($"/api/items/{id}");

        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            var responseContent = await response.Content.ReadAsStringAsync();
            throw new Exception(responseContent);
        }
    }
}