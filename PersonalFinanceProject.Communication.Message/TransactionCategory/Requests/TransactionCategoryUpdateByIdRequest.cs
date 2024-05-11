using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryUpdateByIdRequest
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryUpdateByIdRequest(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}