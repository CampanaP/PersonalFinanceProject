namespace PersonalFinanceProject.Communication.Message.RevenueSource.Responses
{
    public record RevenueSourceResponseItem
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required Guid UserId { get; set; }
    }
}