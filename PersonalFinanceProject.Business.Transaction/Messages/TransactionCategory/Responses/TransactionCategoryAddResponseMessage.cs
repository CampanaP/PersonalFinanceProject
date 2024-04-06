using System.Diagnostics.CodeAnalysis;
using Wolverine.Attributes;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Responses
{
    [WolverineMessage]
    public record TransactionCategoryAddResponseMessage
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryAddResponseMessage(int id)
        {
            Id = id;
        }
    }
}