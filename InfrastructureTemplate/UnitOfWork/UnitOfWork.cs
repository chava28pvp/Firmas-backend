using InfrastructureTemplate.Application.Interfaces;
using InfrastructureTemplate.Context;
using InfrastructureTemplate.Model;
using InfrastructureTemplate.Repository;
using System.Threading.Tasks;

namespace InfrastructureTemplate.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        private IGenericRepository<ArchiveUrls> _archiveUrlsRepository;
        public IGenericRepository<ArchiveUrls> ArchiveUrlsRepository => _archiveUrlsRepository = new GenericRepository<ArchiveUrls>(_context);

        private IGenericRepository<SingularPoint> _singularPointRepository;
        public IGenericRepository<SingularPoint> SingularPointRepository => _singularPointRepository = new GenericRepository<SingularPoint>(_context);

        private IGenericRepository<TypesArchive> _typesArchiveRepository;
        public IGenericRepository<TypesArchive> TypesArchiveRepository => _typesArchiveRepository = new GenericRepository<TypesArchive>(_context);

        // Sigue agregando los que necesites de tus modelos



        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
