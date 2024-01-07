using API.Controllers.Presenters.Request.Categorias;

namespace API.Controllers.Presenters.Categorias
{
    public interface ICategoriasPresenter
    {
        Task SaveAsync(CategoriasCreateOrUpdateRequest request);
    }
}
