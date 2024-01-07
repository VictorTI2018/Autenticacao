using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using SQLServer.Context;
using System.Linq.Expressions;

namespace SQLServer.Repositories
{
    public class UserRepository(MyContext context) : BaseRepository<UserEntity>(context),
        IUserRepository
    { }
}
