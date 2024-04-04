namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses
{
    public record TransactionCategoryGetListResponseMessage
    {
        public IEnumerable<TransactionCategoryMessageItem>? TransactionCategories { get; set; }

        public TransactionCategoryGetListResponseMessage()
        {
            TransactionCategories = null;
        }
    }
}