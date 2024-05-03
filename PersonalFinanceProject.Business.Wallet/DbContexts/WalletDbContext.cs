using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Library.EntityFramework.DbContexts;

namespace PersonalFinanceProject.Business.Wallet.DbContexts
{
    public class WalletDbContext : GenericDbContext<WalletDbContext>
    {
        public WalletDbContext() : base()
        {
        }

        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        public DbSet<RevenueSource> RevenueSources { get; set; }

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