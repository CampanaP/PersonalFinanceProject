using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceProject.Library.EntityFramework.Attributes;

namespace PersonalFinanceProject.Business.Transaction.EntityConfigurations
{
    internal class TransactionConfiguration : EntityConfigurationAttribute<Entities.Transaction>
    {
        public override void Configure(EntityTypeBuilder<Entities.Transaction> builder)
        {
            builder.HasKey(new string[] { "Id" });
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.Amount).IsRequired();

            builder.Property(p => p.CategoryId).IsRequired();

            builder.Property(p => p.SourceId).IsRequired();

            builder.Property(p => p.TypeId).IsRequired();

            builder.Property(p => p.CreateDate)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.UpdateDate)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(new string[] { "Id" });
            builder.HasIndex(new string[] { "CategoryId" });
            builder.HasIndex(new string[] { "SourceId" });
            builder.HasIndex(new string[] { "TypeId" });
        }
    }
}