using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
        where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<T?> FilterAsync(Expression<Func<T, bool>> expression);

    }
}
