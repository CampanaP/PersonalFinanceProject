using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceProject.Business.Transactions.Entities;

namespace PersonalFinanceProject.Business.Transactions.EntityConfigurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //TODO CONFIGURE TABLE TRANSACTIONS WITH INDEX, PK, FK, NOT NULLABLE
        }
    }
}