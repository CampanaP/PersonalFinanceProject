using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.TransactionCategory.Responses
{
    public record TransactionCategoryAddResponse
    {
        public required int Id { get; set; }

        [SetsRequiredMembers]
        public TransactionCategoryAddResponse(int id)
        {
            Id = id;
        }
    }
}