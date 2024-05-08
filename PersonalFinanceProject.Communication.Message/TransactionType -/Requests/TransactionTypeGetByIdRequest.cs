using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionType.Requests
{
    public record TransactionTypeGetByIdRequest
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionTypeGetByIdRequest(int id)
        {
            Id = id;
        }
    }
}