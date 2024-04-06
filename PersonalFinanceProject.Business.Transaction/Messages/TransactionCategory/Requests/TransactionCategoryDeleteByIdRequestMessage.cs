using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests
{
    [WolverineMessage]
    public record TransactionCategoryDeleteByIdRequestMessage
    {
        public required int Id { get; set; }
    }
}