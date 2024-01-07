using API.Controllers.Presenters.Categorias;
using API.Controllers.Presenters.Request.Categorias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriasController(ICategoriasPresenter categoriasPresenter) : ControllerBase
    {
        private readonly ICategoriasPresenter _categoriaPresenter = categoriasPresenter;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoriasCreateOrUpdateRequest request)
        {
            await _categoriaPresenter.SaveAsync(request);
            return Ok(new { status = true });
        }
    }
}
