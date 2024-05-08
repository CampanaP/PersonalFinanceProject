namespace PersonalFinanceProject.Communication.Message.Transaction.Responses
{
    public record TransactionGetListResponse
    {
        public IEnumerable<TransactionResponseItem>? Transactions { get; set; }

        public TransactionGetListResponse()
        {
            Transactions = null;
        }
    }
}