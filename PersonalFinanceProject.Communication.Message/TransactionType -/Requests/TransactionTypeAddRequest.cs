using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionType.Requests
{
    public record TransactionTypeAddRequest
    {
        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionTypeAddRequest(string name)
        {
            Name = name;
        }
    }
}