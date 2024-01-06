using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task AddAsync(UserEntity user);

        Task<UserEntity?> FilterAsync(Expression<Func<UserEntity, bool>> expression);
    }
}
