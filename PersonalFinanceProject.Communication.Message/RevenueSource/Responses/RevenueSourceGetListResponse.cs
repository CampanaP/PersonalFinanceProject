namespace PersonalFinanceProject.Communication.Message.RevenueSource.Responses
{
    public record RevenueSourceGetListResponse
    {
        public IEnumerable<RevenueSourceResponseItem>? RevenueSources { get; set; }

        public RevenueSourceGetListResponse()
        {
            RevenueSources = null;
        }
    }
}