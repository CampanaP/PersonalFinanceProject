namespace PersonalFinanceProject.Communication.Message.RevenueSource.Requests
{
    public record RevenueSourceUpdateRequest
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required Guid UserId { get; set; }
    }
}