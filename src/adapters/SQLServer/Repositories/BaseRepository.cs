using Domain.Entities;
using Domain.Interfaces.Repositories;
using Shared.Exceptions;
using SQLServer.Context;

namespace SQLServer.Repositories
{
    public abstract class BaseRepository<T>(MyContext context) : IBaseRepository<T>
        where T : BaseEntity 
    {
        private readonly MyContext _context = context;


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
