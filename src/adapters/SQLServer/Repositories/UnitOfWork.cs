using Domain.Interfaces.Repositories;
using SQLServer.Context;

namespace SQLServer.Repositories
{
    public class UnitOfWork(MyContext context) : IUnitOfWork
    {
        private readonly MyContext _context = context;

        private bool _disposed;
        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
