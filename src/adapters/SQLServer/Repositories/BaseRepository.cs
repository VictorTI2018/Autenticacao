using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;
using SQLServer.Context;
using System.Linq.Expressions;

namespace SQLServer.Repositories
{
    public abstract class BaseRepository<T>(MyContext context) : IBaseRepository<T>
        where T : BaseEntity 
    {
        private readonly MyContext _context = context;

        public async Task<T?> FilterAsync(Expression<Func<T, bool>> expression)
            => await _context.Set<T>().Where(expression).FirstOrDefaultAsync();

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                return (await _context.Set<T>().AddAsync(entity)).Entity;
            }catch (Exception ex)
            {
                throw new InfraException(ex);
            }
        }
    }
}
