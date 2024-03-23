using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProject.Business.Transactions.Entities
{
    [Table("transactions")]
    internal class Transaction
    {
        public Guid Id { get; set; }

        public double Amount { get; set; }

        public int CategoryId { get; set; }

        public int SourceId { get; set; }

        public int TypeId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}