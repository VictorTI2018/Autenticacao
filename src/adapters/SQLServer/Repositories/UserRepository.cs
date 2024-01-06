using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLServer.Context;
using System.Linq.Expressions;

namespace SQLServer.Repositories
{
    public class UserRepository(MyContext context) : BaseRepository<UserEntity>(context),
        IUserRepository
    {
        private readonly MyContext _context = context;

        public async Task<UserEntity?> FilterAsync(Expression<Func<UserEntity, bool>> expression)
            => await _context.Set<UserEntity>().Where(expression).FirstOrDefaultAsync();
    }
}
