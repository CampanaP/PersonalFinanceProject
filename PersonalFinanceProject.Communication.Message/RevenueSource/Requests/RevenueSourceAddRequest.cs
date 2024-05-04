using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Communication.Message.RevenueSource.Requests
{
    public record RevenueSourceAddRequest
    {
        public required string Name { get; set; }

        public required Guid UserId { get; set; }

        [SetsRequiredMembers]
        public RevenueSourceAddRequest(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}