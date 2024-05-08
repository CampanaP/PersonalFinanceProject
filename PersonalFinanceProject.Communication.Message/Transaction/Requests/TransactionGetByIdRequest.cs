using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.Transaction.Requests
{
    public record TransactionGetByIdRequest
    {
        public required Guid Id { get; set; }

        [SetsRequiredMembers]
        public TransactionGetByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}