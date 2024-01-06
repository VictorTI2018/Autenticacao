using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
    }
}
