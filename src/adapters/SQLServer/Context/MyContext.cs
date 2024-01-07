using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SQLServer.Mapping;

namespace SQLServer.Context
{
    public class MyContext(DbContextOptions<MyContext> options) : DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityMapping());
            modelBuilder.ApplyConfiguration(new CategoriasEntityMapping());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=Catalogo;Trusted_Connection=True;Encrypt=False");
            return new MyContext(optionsBuilder.Options);
        }
    }
}
