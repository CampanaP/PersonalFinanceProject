using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Business.Wallet.Entities
{
    public class RevenueSource
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required Guid UserId { get; set; }

        public required DateTime CreateDate { get; set; }

        public required DateTime UpdateDate { get; set; }

        [SetsRequiredMembers]
        public RevenueSource(Guid id, string name, Guid userId, DateTime createDate, DateTime updateDate)
        {
            Id = id;
            Name = name;
            UserId = userId;
            CreateDate = createDate;
            UpdateDate = updateDate;
        }
    }
}