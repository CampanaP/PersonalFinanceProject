namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests
{
    public record TransactionCategoryGetByIdRequestMessage
    {
        public int Id { get; set; }
    }
}