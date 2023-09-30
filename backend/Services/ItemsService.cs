using ItemsCrud.Models;
using ItemsCrud.Persistence;
using ItemsCrud.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemsCrud.Services;

public class ItemsService : IItemsService
{
    private readonly ItemsContext _itemsContext;

    public ItemsService(ItemsContext itemsContext)
    {
        _itemsContext = itemsContext;
    }

    public Task<List<ItemListingModel>> GetAllItems(CancellationToken cancellationToken) => _itemsContext.Items
       .Select(x => new ItemListingModel
       {
           Id = x.Id,
           Name = x.Name,
       })
       .OrderBy(x => x.Name)
       .ToListAsync(cancellationToken);

    public async Task<ItemViewModel> GetItem(Guid id, CancellationToken cancellationToken)
    {
        var item = await _itemsContext.Items
            .Where(x => x.Id == id)
            .Select(x => new ItemViewModel
            {
                Name = x.Name,
                Stock = x.Stock,
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (item is null)
        {
            throw new Exception();
        }

        return item;
    }

    public async Task<Guid> AddItem(ItemViewModel item, CancellationToken cancellationToken)
    {
        var newItem = _itemsContext.Items.Add(new Item
        {
            Name = item.Name,
            Stock = item.Stock,
        });

        await _itemsContext.SaveChangesAsync(cancellationToken);

        return newItem.Entity.Id;
    }

    public async Task UpdateItem(Guid id, ItemViewModel item, CancellationToken cancellationToken)
    {
        var entity = await _itemsContext.Items
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
        {
            throw new Exception();
        }

        entity.Name = item.Name;
        entity.Stock = item.Stock;

        await _itemsContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveItem(Guid id, CancellationToken cancellationToken)
    {
        var item = await _itemsContext.Items.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (item is null)
        {
            throw new Exception();
        }

        _itemsContext.Items.Remove(item);

        await _itemsContext.SaveChangesAsync(cancellationToken);
    }
}