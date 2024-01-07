using API.Controllers.Presenters.Request.Categorias;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace API.Controllers.Presenters.Categorias
{
    public class CategoriasPresenter(ICategoriasService categoriasService,
        IUnitOfWork unitOfWork) : ICategoriasPresenter
    {
        private readonly ICategoriasService _categoriasService = categoriasService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task SaveAsync(CategoriasCreateOrUpdateRequest request)
        {
            CategoriasEntity categorias = new(request.Nome,
                request.Descricao);

            await _categoriasService.AddAsync(categorias);

            await _unitOfWork.CommitAsync();
        }
    }
}
