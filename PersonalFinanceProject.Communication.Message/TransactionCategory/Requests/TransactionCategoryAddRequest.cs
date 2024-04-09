namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryAddRequest
    {
        public required string Name { get; set; }
    }
}