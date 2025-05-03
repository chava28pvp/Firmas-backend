using InfrastructureTemplate.Model;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureTemplate.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
