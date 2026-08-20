using Microsoft.EntityFrameworkCore;
using UserManagment.AggregateRoot.Entities;

namespace TestProject.DAL.Context
{
    public class PortalDbContext:DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> option):base(option){}

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);
        }
    }
}