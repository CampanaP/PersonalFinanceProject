using PersonalFinanceProject.Business.Wallet.Entities;
using PersonalFinanceProject.Library.EntityFramework.Specifications;

namespace PersonalFinanceProject.Business.Wallet.Specifications
{
    internal class RevenueSourceUpdateSpecification : UpdateSpecification<RevenueSource>
    {
        public RevenueSourceUpdateSpecification(string name, Guid userId, DateTime createDate, DateTime updateDate)
            : base(u =>
                u.SetProperty(rs => rs.Name, name)
                .SetProperty(rs => rs.UserId, userId)
                .SetProperty(rs => rs.CreateDate, createDate)
                .SetProperty(rs => rs.UpdateDate, updateDate))
        {
        }
    }
}