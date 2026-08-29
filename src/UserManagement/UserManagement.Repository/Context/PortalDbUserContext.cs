using Microsoft.EntityFrameworkCore;
using UserManagement.AggregateRoot;

namespace UserManagement.Repository.Context
{
    public class PortalDbUserContext:DbContext
    {
        public PortalDbUserContext(DbContextOptions<PortalDbUserContext> option):base(option){}

        public DbSet<UsersAggregateRoot> Users => Set<UsersAggregateRoot>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbUserContext).Assembly);
        }
    }
}