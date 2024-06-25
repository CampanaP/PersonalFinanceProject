using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Library.EntityFramework.Extensions
{
    public static class SpecificationExtension
    {
        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> query, QuerySpecification<TEntity> querySpecification) where TEntity : class
        {
            if (querySpecification.Criteria is not null)
            {
                query = query.Where(querySpecification.Criteria);
            }

            if (querySpecification.Includes?.Any() ?? false)
            {
                query = querySpecification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (querySpecification.Skip is not null)
            {
                query = query.Skip(querySpecification.Skip.Value);
            }

            if (querySpecification.Take is not null)
            {
                query = query.Take(querySpecification.Take.Value);
            }

            if (querySpecification.OrderBy is not null)
            {
                query = query.OrderBy(querySpecification.OrderBy);
            }

            if (querySpecification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(querySpecification.OrderByDescending);
            }

            return query;
        }
    }
}