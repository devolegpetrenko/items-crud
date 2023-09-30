using frontend.Models;

namespace frontend.Data;

public interface IItemsService
{
    Task<List<ItemListingModel>> GetAllItems();
    Task<ItemViewModel> GetItem(Guid id);
    Task<Guid> AddItem(ItemViewModel item);
    Task UpdateItem(Guid id, ItemViewModel item);
    Task RemoveItem(Guid id);
}