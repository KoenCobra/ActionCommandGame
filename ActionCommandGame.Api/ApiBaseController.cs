using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandGame.Api
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
    }
}
