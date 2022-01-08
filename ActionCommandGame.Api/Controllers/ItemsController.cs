using ActionCommandGame.Api.Authentication.Extensions;
using ActionCommandGame.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    public class ItemsController : ApiBaseController
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("items")]
        public async Task<IActionResult> Find()
        {
            var result = await _itemService.FindAsync(User.GetId());
            return Ok(result);
        }

        [HttpDelete("items/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _itemService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
