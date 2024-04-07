using System.Diagnostics.CodeAnalysis;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests
{
    [WolverineMessage]
    public record TransactionCategoryGetByIdRequestMessage
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryGetByIdRequestMessage(int id)
        {
            Id = id;
        }
    }
}