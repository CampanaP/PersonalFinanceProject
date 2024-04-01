using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProject.Business.Transactions.Entities
{
    public class TransactionCategory
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}