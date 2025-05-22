using InfrastructureTemplate.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureTemplate.Application.Interfaces
{
    public interface ISingularPointRepository: IGenericRepository<SingularPoint>
    {
        Task AddSingularPointWithFileAsync(SingularPoint singularPoint);

    }
}
