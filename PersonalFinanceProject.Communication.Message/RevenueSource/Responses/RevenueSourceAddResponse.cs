using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.RevenueSource.Responses
{
    public record RevenueSourceAddResponse
    {
        public required Guid Id { get; set; }

        [SetsRequiredMembers]
        public RevenueSourceAddResponse(Guid id)
        {
            Id = id;
        }
    }
}