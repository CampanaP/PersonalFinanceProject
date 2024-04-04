using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory
{
    public record TransactionCategoryMessageItem
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryMessageItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}