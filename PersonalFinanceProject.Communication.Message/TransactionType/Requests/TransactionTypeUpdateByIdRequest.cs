using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionType.Requests
{
    public record TransactionTypeUpdateByIdRequest
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionTypeUpdateByIdRequest(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}