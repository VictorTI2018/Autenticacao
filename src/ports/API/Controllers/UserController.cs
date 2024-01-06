using API.Controllers.Presenters.Request.User;
using API.Controllers.Presenters.User;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(IUserPresenter userPresenter) : ControllerBase
    {
        private readonly IUserPresenter _userPresenter = userPresenter;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCreateAndUpdateRequest request)
        {
            await _userPresenter.SaveAsync(request);
            return Ok(new { token = GenerateToken.JWT(request.Email, Environment.GetEnvironmentVariable("TOKEN_SECRET")) });
        }
    }
}
