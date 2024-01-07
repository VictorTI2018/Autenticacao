using Application.Validators.Categorias;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Shared.Exceptions;

namespace Application.Services.Categorias
{
    public class CategoriasService(ICategoriasRepository categoriasRepository)
        : ICategoriasService
    {
        private readonly ICategoriasRepository _categoriasRepository = categoriasRepository;

        public async Task AddAsync(CategoriasEntity categoriasEntity)
        {
            var validator = new CategoriasCreateValidator();
            var result = await validator.ValidateAsync(categoriasEntity);

            if (!result.IsValid)
                throw new BusinessException(result.Errors.Select(e => e.ErrorMessage).ToList());

            var recoveryCategoria = await _categoriasRepository.FilterAsync(c => c.Nome.Equals(categoriasEntity.Nome));

            if (recoveryCategoria is not null)
                throw new BusinessException(["Categória já cadastrada."]);

            await _categoriasRepository.AddAsync(categoriasEntity);
        }
    }
}
