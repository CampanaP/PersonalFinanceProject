using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceProject.Library.EntityFramework.DbContexts
{
    public class GenericDbContext : DbContext
    {
        public GenericDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}