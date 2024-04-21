using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryUpdateRequest
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryUpdateRequest(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}