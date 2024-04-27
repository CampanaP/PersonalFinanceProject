namespace PersonalFinanceProject.Communication.Message.RevenueSource.Responses
{
    public record RevenueSourceGetByIdResponse
    {
        public RevenueSourceResponseItem? RevenueSource { get; set; }

        public RevenueSourceGetByIdResponse()
        {
            RevenueSource = null;
        }
    }
}