using PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications;
using System.Linq.Expressions;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.Specifications
{
    public class GenericSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; }

        public List<Expression<Func<T, object>>> Includes { get; set; }

        public Expression<Func<T, object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDescending { get; set; }

        public void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        public void AddOrderBy(Expression<Func<T, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }
    }
}