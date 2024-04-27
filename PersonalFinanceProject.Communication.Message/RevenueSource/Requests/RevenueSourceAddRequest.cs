namespace PersonalFinanceProject.Communication.Message.RevenueSource.Requests
{
    public record RevenueSourceAddRequest
    {
        public required string Name { get; set; }

        public required Guid UserId { get; set; }
    }
}