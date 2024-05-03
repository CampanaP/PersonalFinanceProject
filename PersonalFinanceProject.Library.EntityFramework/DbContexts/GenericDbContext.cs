using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceProject.Library.EntityFramework.DbContexts
{
    public class GenericDbContext<T> : DbContext where T : DbContext
    {
        public GenericDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public GenericDbContext(DbContextOptions<T> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.LazyLoadingEnabled = false;
        }

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