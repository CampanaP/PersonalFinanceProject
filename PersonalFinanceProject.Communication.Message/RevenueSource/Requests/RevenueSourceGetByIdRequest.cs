using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.RevenueSource.Requests
{
    public record RevenueSourceGetByIdRequest
    {
        public required Guid Id { get; set; }

        [SetsRequiredMembers]
        public RevenueSourceGetByIdRequest(Guid id)
        {
            Id = id;
        }
    }
}