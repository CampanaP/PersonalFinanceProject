namespace PersonalFinanceProject.Communication.Message.RevenueSource.Requests
{
    public record RevenueSourceDeleteByIdRequest
    {
        public required Guid Id { get; set; }
    }
}