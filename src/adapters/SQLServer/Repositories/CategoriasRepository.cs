using Domain.Entities;
using Domain.Interfaces.Repositories;
using SQLServer.Context;

namespace SQLServer.Repositories
{
    public class CategoriasRepository(MyContext context) : 
        BaseRepository<CategoriasEntity>(context),
        ICategoriasRepository
    {
    }
}
