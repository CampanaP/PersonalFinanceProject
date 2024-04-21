using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryAddRequest
    {
        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryAddRequest(string name)
        {
            Name = name;
        }
    }
}