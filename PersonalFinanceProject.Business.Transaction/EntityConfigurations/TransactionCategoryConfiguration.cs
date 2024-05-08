using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceProject.Business.Transaction.Entities;
using PersonalFinanceProject.Library.EntityFramework.Attributes;

namespace PersonalFinanceProject.Business.Transaction.EntityConfigurations
{
    internal class TransactionCategoryConfiguration : EntityConfigurationAttribute<TransactionCategory>
    {
        public override void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.HasKey(new string[] { "Id" });
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

            builder.HasIndex(new string[] { "Id" });
        }
    }
}