using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProject.Business.Transaction.Entities
{
    public class TransactionCategory
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}