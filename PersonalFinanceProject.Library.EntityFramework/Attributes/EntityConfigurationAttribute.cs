using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PersonalFinanceProject.Library.EntityFramework.Attributes
{
    public abstract class EntityConfigurationAttribute<T> : IEntityTypeConfiguration<T> where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder)
    }
}