using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionType.Requests
{
    public record TransactionTypeDeleteByIdRequest
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionTypeDeleteByIdRequest(int id)
        {
            Id = id;
        }
    }
}