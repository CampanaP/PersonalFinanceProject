using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.Transaction.Requests
{
    public record TransactionDeleteByIdRequest
    {
        public required Guid Id { get; set; }

        [SetsRequiredMembers]
        public TransactionDeleteByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}