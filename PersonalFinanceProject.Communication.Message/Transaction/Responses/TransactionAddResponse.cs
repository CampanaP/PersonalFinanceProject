using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.Transaction.Responses
{
    public record TransactionAddResponse
    {
        public required Guid Id { get; set; }

        [SetsRequiredMembers]
        public TransactionAddResponse(Guid id)
        {
            Id = id;
        }
    }
}