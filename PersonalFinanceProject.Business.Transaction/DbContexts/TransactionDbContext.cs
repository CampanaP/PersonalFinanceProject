using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Library.EntityFramework.DbContexts;

namespace PersonalFinanceProject.Business.Transaction.DbContexts
{
    public class TransactionDbContext : GenericDbContext<TransactionDbContext>
    {
        public TransactionDbContext()
        {
        }

        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }

        public DbSet<Entities.Transaction> Transactions { get; set; }
        public DbSet<TransactionCategory> TransactionCategories { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }

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