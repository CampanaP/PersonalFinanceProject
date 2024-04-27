namespace PersonalFinanceProject.Business.Wallet.Entities
{
    public class RevenueSource
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required Guid UserId { get; set; }

        public required DateTime CreateDate { get; set; }

        public required DateTime UpdateDate { get; set; }
    }
}