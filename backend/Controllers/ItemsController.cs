using ItemsCrud.Models;
using ItemsCrud.Services;
using Microsoft.AspNetCore.Mvc;

namespace ItemsCrud.Controllers;

[ApiController]
[Route("api/items")]
public class ItemsController : ControllerBase
{
    private readonly IItemsService _itemsService;

    public ItemsController(IItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet("")]
    [ProducesResponseType(typeof(List<ItemListingModel>), 200)]
    public async Task<IActionResult> GetAllItems(CancellationToken cancellationToken)
    {
        var items = await _itemsService.GetAllItems(cancellationToken);
        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(ItemViewModel), 200)]
    public async Task<IActionResult> GetItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var item = await _itemsService.GetItem(id, cancellationToken);
        return Ok(item);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    public async Task<IActionResult> AddItem([FromBody] ItemViewModel item, CancellationToken cancellationToken)
    {
        var id = await _itemsService.AddItem(item, cancellationToken);
        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] ItemViewModel item, CancellationToken cancellationToken)
    {
        await _itemsService.UpdateItem(id, item, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveItem([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _itemsService.RemoveItem(id, cancellationToken);
        return Ok();
    }
}