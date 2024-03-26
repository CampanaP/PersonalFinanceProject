using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProject.Business.Transactions.Entities
{
    [Table("transactionTypes")]
    public class TransactionType
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}