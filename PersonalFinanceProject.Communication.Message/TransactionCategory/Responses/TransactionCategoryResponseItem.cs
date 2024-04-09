using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Responses
{
    public record TransactionCategoryResponseItem
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryResponseItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}