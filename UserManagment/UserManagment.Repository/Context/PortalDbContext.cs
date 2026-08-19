using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.DAL.Entities;

namespace TestProject.DAL.Context
{
    public class PortalDbContext:DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> option):base(option){}
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<JobApplication> JobApplications => Set<JobApplication>();
        public DbSet<JobPost> JobPosts => Set<JobPost>();
        public DbSet<SavedJob> SavedJobs=> Set<SavedJob>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortalDbContext).Assembly);
        }
    }
}