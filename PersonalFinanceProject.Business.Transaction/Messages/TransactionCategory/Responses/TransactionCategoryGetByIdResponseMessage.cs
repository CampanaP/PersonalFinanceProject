using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses
{
    [WolverineMessage]
    public record TransactionCategoryGetByIdResponseMessage
    {
        public TransactionCategoryMessageItem? TransactionCategory { get; set; }

        public TransactionCategoryGetByIdResponseMessage()
        {
            TransactionCategory = null;
        }
    }
}