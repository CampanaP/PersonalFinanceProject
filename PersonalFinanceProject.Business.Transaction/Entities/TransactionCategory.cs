using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Business.Transaction.Entities
{
    public class TransactionCategory
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public TransactionCategory()
        {
        }

        [SetsRequiredMembers]
        public TransactionCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}