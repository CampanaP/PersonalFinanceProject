using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Requests
{
    public record TransactionCategoryDeleteByIdRequest
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryDeleteByIdRequest(int id)
        {
            Id = id;
        }
    }
}