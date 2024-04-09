namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Responses
{
    public record TransactionCategoryGetByIdResponse
    {
        public TransactionCategoryResponseItem? TransactionCategory { get; set; }

        public TransactionCategoryGetByIdResponse()
        {
            TransactionCategory = null;
        }
    }
}