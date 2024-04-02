namespace PersonalFinanceProject.Business.Transaction.Messages.Responses
{
    public class TransactionCategoryResponseMessage
    {
        public record TransactionCategoryItem(int Id, string Name);

        public record GetByIdResponse(TransactionCategoryItem? TransactionCategory);

        public record GetListResponse(IEnumerable<TransactionCategoryItem> TransactionCategories);
    }
}
