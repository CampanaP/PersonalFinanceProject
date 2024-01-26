using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.ExtensionMethods
{
    internal static class SpecificationExtensions
    {
        public static IQueryable<T> Search<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class
        {
            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderBy);
            }

            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}