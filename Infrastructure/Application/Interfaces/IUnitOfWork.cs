using Infrastructure.Model;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISingularPointRepository SingularPoints { get; }
        Task<int> CompleteAsync();
    }
}
