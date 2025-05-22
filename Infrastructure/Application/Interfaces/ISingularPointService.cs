using Infrastructure.DTOs;
using Infrastructure.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Application.Interfaces
{
    public interface ISingularPointService
    {
        Task CreateSingularPointAsync(CreateSingularPointDto dto, string uploadsFolder);
    }

}
