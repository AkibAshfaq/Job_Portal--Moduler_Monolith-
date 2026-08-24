using Microsoft.EntityFrameworkCore;
using UserManagement.AggregateRoot;

namespace UserManagement.Repository.Context
{
    public class PortalDbContext:DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> option):base(option){}

        public DbSet<UsersAggregateRoot> Users => Set<UsersAggregateRoot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);
        }
    }
}