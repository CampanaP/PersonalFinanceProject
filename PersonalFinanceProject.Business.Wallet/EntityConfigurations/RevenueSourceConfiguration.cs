using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Library.EntityFramework.Attributes;

namespace PersonalFinanceProject.Business.Wallet.EntityConfigurations
{
    internal class RevenueSourceConfiguration : EntityConfigurationAttribute<RevenueSource>
    {
        public override void Configure(EntityTypeBuilder<RevenueSource> builder)
        {
            builder.HasKey(new string[] { "Id" });
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();

            builder.Property(p => p.UserId).IsRequired();

            builder.Property(p => p.CreateDate)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(p => p.UpdateDate)
                .HasDefaultValue(DateTime.Now)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasIndex(new string[] { "Id" });
            builder.HasIndex(new string[] { "UserId" });
        }
    }
}