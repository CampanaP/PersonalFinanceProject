using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Wallet.Specifications
{
    internal class RevenueSourceGetByIdSpecification : GenericSpecification<RevenueSource>
    {
        public RevenueSourceGetByIdSpecification(Guid id) : base(rs => rs.Id == id)
        {
        }
    }
}