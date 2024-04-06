using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses
{
    [WolverineMessage]
    public record TransactionCategoryGetListResponseMessage
    {
        public IEnumerable<TransactionCategoryMessageItem>? TransactionCategories { get; set; }

        public TransactionCategoryGetListResponseMessage()
        {
            TransactionCategories = null;
        }
    }
}