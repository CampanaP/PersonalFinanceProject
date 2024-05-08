using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Wallet.Specifications.RevenueSource
{
    internal class RevenueSourceGetByIdQuerySpecification : QuerySpecification<Entities.RevenueSource>
    {
        public RevenueSourceGetByIdQuerySpecification(Guid id) : base(rs => rs.Id == id)
        {
        }
    }
}