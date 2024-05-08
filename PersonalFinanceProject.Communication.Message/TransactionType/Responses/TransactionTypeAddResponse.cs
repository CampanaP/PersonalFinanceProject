using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionType.Responses
{
    public record TransactionTypeAddResponse
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionTypeAddResponse(int id)
        {
            Id = id;
        }
    }
}