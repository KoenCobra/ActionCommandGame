using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    public class PositiveGameEventController : ApiBaseController
    {
        private readonly IPositiveGameEventService _positiveGameEventService;

        public PositiveGameEventController(IPositiveGameEventService positiveGameEventService)
        {
            _positiveGameEventService = positiveGameEventService;
        }

        [HttpGet("positiveGameEvents/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _positiveGameEventService.GetAsync(id);
            return Ok(result);
        }

        [HttpGet("positiveGameEvents")]
        public async Task<IActionResult> Find()
        {
            var result = await _positiveGameEventService.FindAsync();
            return Ok(result);
        }

        [HttpPost("positiveGameEvents")]
        public async Task<IActionResult> Create(PositiveGameEventResult positiveGameEventResult)
        {
            var result = await _positiveGameEventService.Create(positiveGameEventResult);
            return Ok(result);
        }

        [HttpPut("positiveGameEvents/{id}")]
        public async Task<IActionResult> Update(int id, PositiveGameEventResult positiveGameEventResult)
        {
            var result = await _positiveGameEventService.Update(id, positiveGameEventResult);
            return Ok(result);
        }

        [HttpDelete("positiveGameEvents/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _positiveGameEventService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
