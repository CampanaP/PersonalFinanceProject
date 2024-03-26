using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transactions.Entities;

namespace PersonalFinanceProject.Business.Transactions.Interfaces.Services
{
    internal interface ITransactionDatabaseService
    {
        DbSet<Transaction> Transactions { get; set; }
    }
}