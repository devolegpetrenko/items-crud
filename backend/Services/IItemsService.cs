using ItemsCrud.Models;

namespace ItemsCrud.Services;

public interface IItemsService
{
    Task<Guid> AddItem(ItemViewModel item, CancellationToken cancellationToken);
    Task<List<ItemListingModel>> GetAllItems(CancellationToken cancellationToken);
    Task<ItemViewModel> GetItem(Guid id, CancellationToken cancellationToken);
    Task RemoveItem(Guid id, CancellationToken cancellationToken);
    Task UpdateItem(Guid id, ItemViewModel item, CancellationToken cancellationToken);
}