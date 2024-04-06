using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests
{
    [WolverineMessage]
    public record TransactionCategoryUpdateRequestMessage
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}