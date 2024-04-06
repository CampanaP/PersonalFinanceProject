using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests
{
    [WolverineMessage]
    public record TransactionCategoryGetByIdRequestMessage
    {
        public int Id { get; set; }
    }
}