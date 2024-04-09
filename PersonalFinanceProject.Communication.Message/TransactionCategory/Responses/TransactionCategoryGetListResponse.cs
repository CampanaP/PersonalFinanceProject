namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Responses
{
    public record TransactionCategoryGetListResponse
    {
        public IEnumerable<TransactionCategoryResponseItem>? TransactionCategories { get; set; }

        public TransactionCategoryGetListResponse()
        {
            TransactionCategories = null;
        }
    }
}