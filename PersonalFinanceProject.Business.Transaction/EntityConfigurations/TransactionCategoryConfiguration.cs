﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceProject.Business.Transaction.Entities;

namespace PersonalFinanceProject.Business.Transaction.EntityConfigurations
{
    internal class TransactionCategoryConfiguration : IEntityTypeConfiguration<TransactionCategory>
    {
        public void Configure(EntityTypeBuilder<TransactionCategory> builder)
        {
            builder.ToTable("transactionCategories");

            builder.HasKey(new string[] { "Id" });
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).HasMaxLength(255).IsRequired();

            builder.HasIndex(new string[] { "Id" });
        }
    }
}