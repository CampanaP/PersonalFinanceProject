using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PersonalFinanceProject.Library.EntityFramework.Specifications
{
    public abstract class UpdateSpecification<TEntity> where TEntity : class
    {
        public Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>>? Properties { get; }

        protected UpdateSpecification(Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> properties)
        {
            Properties = properties;
        }
    }
}