using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceProject.Business.Transaction.Entities
{
    public class Transaction
    {
        public required Guid Id { get; set; }

        public required double Amount { get; set; }

        public required int CategoryId { get; set; }

        public required int SourceId { get; set; }

        public required int TypeId { get; set; }

        public required DateTime CreateDate { get; set; }

        public required DateTime UpdateDate { get; set; }
    }
}