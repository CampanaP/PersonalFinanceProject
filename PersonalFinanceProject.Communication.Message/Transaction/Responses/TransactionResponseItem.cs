namespace PersonalFinanceProject.Communication.Message.Transaction.Responses
{
    public record TransactionResponseItem
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required double Amount { get; set; }

        public required int CategoryId { get; set; }

        public required int TypeId { get; set; }

        public required Guid SourceId { get; set; }

        public required DateTime CreateDate { get; set; }

        public required DateTime UpdateDate { get; set; }
    }
}