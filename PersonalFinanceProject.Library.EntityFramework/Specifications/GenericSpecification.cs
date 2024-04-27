using System.Linq.Expressions;

namespace PersonalFinanceProject.Library.EntityFramework.Specifications
{
    public abstract class GenericSpecification<TEntity> where TEntity : class
    {
        protected GenericSpecification(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<TEntity, bool>>? Criteria { get; }

        public List<Expression<Func<TEntity, object>>>? Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public int? Skip { get; private set; }

        public int? Take { get; private set; }

        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }

        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> include)
        {
            Includes!.Add(include);
        }

        protected void AddSkip(int skip)
        {
            Skip = skip;
        }

        protected void AddTake(int take)
        {
            Take = take;
        }

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderBy)
        {
            OrderBy = orderBy;
        }

        protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }
    }
}