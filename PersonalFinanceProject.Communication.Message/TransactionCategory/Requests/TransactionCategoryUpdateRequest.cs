namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryUpdateRequest
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}