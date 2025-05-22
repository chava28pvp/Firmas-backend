using Infrastructure.Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.Model;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SingularPointRepository : GenericRepository<SingularPoint>, ISingularPointRepository
    {
        private readonly AppDbContext _context;

        public SingularPointRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddSingularPointWithFileAsync(SingularPoint singularPoint)
        {
            await _context.SingularPoint.AddAsync(singularPoint);
            // No llamas a SaveChanges aquí — se hará desde UnitOfWork
        }
    }

}
