using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface ICategoriasService
    {
        Task AddAsync(CategoriasEntity categoriasEntity);
    }
}
