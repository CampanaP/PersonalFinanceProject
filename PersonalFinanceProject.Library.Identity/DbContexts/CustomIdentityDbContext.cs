using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.EntityFramework.DbContexts;

namespace PersonalFinanceProject.Library.Identity.DbContexts
{
    internal class CustomIdentityDbContext : GenericDbContext<IdentityDbContext>
    {
        public CustomIdentityDbContext() : base()
        {
        }

        //public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext> options) : base(options)
        //{
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}