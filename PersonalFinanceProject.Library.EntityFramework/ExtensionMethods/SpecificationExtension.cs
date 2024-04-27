using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Library.EntityFramework.ExtensionMethods
{
    public static class SpecificationExtension
    {
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> query, GenericSpecification<TEntity> specification) where TEntity : class
        {
            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Includes?.Any() ?? false)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (specification.Skip is not null)
            {
                query = query.Skip(specification.Skip.Value);
            }

            if (specification.Take is not null)
            {
                query = query.Take(specification.Take.Value);
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            return query;
        }
    }
}