using System.Linq.Expressions;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.Interfaces.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>>? Criteria { get; }

        List<Expression<Func<T, object>>>? Includes { get; }

        int? Skip { get; }

        int? Take { get; }
        
        Expression<Func<T, object>>? OrderBy { get; }

        Expression<Func<T, object>>? OrderByDescending { get; }
    }
}