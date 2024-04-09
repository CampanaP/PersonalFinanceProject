using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryGetByIdRequest
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryGetByIdRequest(int id)
        {
            Id = id;
        }
    }
}