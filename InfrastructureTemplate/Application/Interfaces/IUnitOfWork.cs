using InfrastructureTemplate.Model;
using System;
using System.Threading.Tasks;

namespace InfrastructureTemplate.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ArchiveUrls> ArchiveUrlsRepository { get; }
        IGenericRepository<SingularPoint> SingularPointRepository { get; }
        IGenericRepository<TypesArchive> TypesArchiveRepository { get; }
        Task<int> SaveAsync();
    }
}
