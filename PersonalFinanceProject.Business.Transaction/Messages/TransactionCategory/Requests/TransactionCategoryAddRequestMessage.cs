using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests
{
    [WolverineMessage]
    public record TransactionCategoryAddRequestMessage
    {
        public required string Name { get; set; }
    }
}