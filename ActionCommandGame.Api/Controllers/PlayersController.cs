using ActionCommandGame.Api.Authentication.Extensions;
using ActionCommandGame.Services.Abstractions;
using ActionCommandGame.Services.Model.Filters;
using ActionCommandGame.Services.Model.Results;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api.Controllers
{
    public class PlayersController : ApiBaseController
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet("players/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _playerService.GetAsync(id, User.GetId());
            return Ok(result);
        }

        [HttpGet("players")]
        public async Task<IActionResult> Find([FromQuery]PlayerFilter filter)
        {
            var result = await _playerService.FindAsync(filter, User.GetId());
            return Ok(result);
        }

        [HttpPost("players")]
        public async Task<IActionResult> Create(PlayerResult player)
        {
            var result = await _playerService.Create(player, User.GetId());
            return Ok(result);
        }

        [HttpPut("players/{id}")]
        public async Task<IActionResult> Update(int id,PlayerResult player)
        {
            var result = await _playerService.Update(id, player, User.GetId());
            return Ok(result);
        }

        [HttpDelete("players/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = _playerService.Delete(id, User.GetId());
            if (!isDeleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
