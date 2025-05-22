using Infrastructure.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Application.Interfaces
{
    public interface ISingularPointRepository: IGenericRepository<SingularPoint>
    {
        Task AddSingularPointWithFileAsync(SingularPoint singularPoint);

    }
}
