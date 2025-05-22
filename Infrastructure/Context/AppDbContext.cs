using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ArchiveUrls> ArchiveUrls { get; set; }
        public DbSet<SingularPoint> SingularPoint { get; set; }
        public DbSet<TypesArchive> TypesArchive { get; set; }
        public DbSet<AssignedOu> AssignedOu { get; set; }
        public DbSet<AssignedTeam> AssignedTeam { get; set; }
        public DbSet<PersonalizedGroup> PersonalizedGroups { get; set; }
        public DbSet <PersonalizedGroupsOwner> PersonalizedGroupsOwner { get; set; }
        public DbSet <PersonalizedGroupsUser> PersonalizedGroupsUser { get; set; }
        public DbSet<AssignedPersonalizedGroup> AssignedPersonalizedGroup { get; set; }
        public DbSet<RelationsSign> RelationsSigns { get; set; }
        public DbSet<TypesSign> TypesSigns { get; set; }
        public DbSet<Sign> Signs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SingularPoint>()
                .HasOne(sp => sp.TypesArchive)
                .WithMany(ta => ta.SingularPoints)
                .HasForeignKey(sp => sp.IdTypesArchive);

            modelBuilder.Entity<ArchiveUrls>()
       .HasOne(a => a.SingularPoint)
       .WithMany(s => s.ArchiveUrls)
       .HasForeignKey(a => a.IdSingularPoint);
        }

    }
}
