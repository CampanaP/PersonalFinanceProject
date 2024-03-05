using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.ExtensionMethods
{
    public static class SpecificationExtension
    {
        public static IQueryable<T> Search<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class
        {
            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
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

            if (specification.Includes?.Any() ?? false)
            {
                query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            return query;
        }
    }
}