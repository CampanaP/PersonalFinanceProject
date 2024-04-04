namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses
{
    public record TransactionCategoryGetByIdResponseMessage
    {
        public TransactionCategoryMessageItem? TransactionCategory { get; set; }

        public TransactionCategoryGetByIdResponseMessage()
        {
            TransactionCategory = null;
        }
    }
}