using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProject.Business.Transaction.Entities
{
    public class TransactionType
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}