using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.RevenueSource.Requests
{
    public record RevenueSourceDeleteByIdRequest
    {
        public required Guid Id { get; set; }

        [SetsRequiredMembers]
        public RevenueSourceDeleteByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}