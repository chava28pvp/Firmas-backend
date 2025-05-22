using Infrastructure.Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Model;
using Infrastructure.Repository;
using Infrastructure.Services;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ISingularPointRepository SingularPoints { get; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            SingularPoints = new SingularPointRepository(_context);

        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose() => _context.Dispose();
    }
}
