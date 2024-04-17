using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transaction.Entities;

namespace PersonalFinanceProject.Business.Transaction.DbContexts
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Entities.Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}