namespace PersonalFinanceProject.Business.Transactions.Messages.Responses
{
    public class TransactionCategoryResponseMessage
    {
        public record TransactionCategoryItem(int id, string name);

        public record GetByIdResponse(TransactionCategoryItem? transactionCategory);

        public record GetListResponse(List<TransactionCategoryItem> transactionCategories);
    }
}
