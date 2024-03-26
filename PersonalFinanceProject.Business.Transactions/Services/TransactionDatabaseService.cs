using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transactions.Entities;
using PersonalFinanceProject.Business.Transactions.Interfaces.Services;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Attributes;
using PersonalFinanceProject.Infrastructure.EntityFramework;

namespace PersonalFinanceProject.Business.Transactions.Services
{
    [ScopedLifetime]
    internal class TransactionDatabaseService : GenericDbContext, ITransactionDatabaseService
    {
        public TransactionDatabaseService()
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}