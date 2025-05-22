using InfrastructureTemplate.DTOs;
using InfrastructureTemplate.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureTemplate.Application.Interfaces
{
    public interface ISingularPointService
    {
        Task CreateSingularPointAsync(CreateSingularPointDto dto, string uploadsFolder);
    }

}
