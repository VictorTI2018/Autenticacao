using API.Controllers.Presenters.Request.User;
using API.Controllers.Presenters.User;
using Microsoft.AspNetCore.Mvc;
using Shared.Utils;

namespace API.Controllers
{
    /// <summary>
    /// Controller para gerenciar autenticação
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController(IUserPresenter userPresenter) : ControllerBase
    {
        private readonly IUserPresenter _userPresenter = userPresenter;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthRequest request)
        {
            await _userPresenter.GetUserByEmail(request);

            return Ok(new { token = GenerateToken.JWT(request.Email, Environment.GetEnvironmentVariable("TOKEN_SECRET")) });
        }
    }
}
