namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryDeleteByIdRequest
    {
        public required int Id { get; set; }
    }
}