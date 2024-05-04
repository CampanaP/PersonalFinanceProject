using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Wallet.Specifications
{
    internal class RevenueSourceGetByIdQuerySpecification : QuerySpecification<RevenueSource>
    {
        public RevenueSourceGetByIdQuerySpecification(Guid id) : base(rs => rs.Id == id)
        {
        }
    }
}