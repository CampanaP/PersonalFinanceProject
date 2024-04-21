namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Responses
{
    public record TransactionCategoryResponseItem
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}