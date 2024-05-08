namespace PersonalFinanceProject.Communication.Message.Transaction.Responses
{
    public record TransactionGetByIdResponse
    {
        public TransactionResponseItem? Transaction { get; set; }

        public TransactionGetByIdResponse()
        {
            Transaction = null;
        }
    }
}