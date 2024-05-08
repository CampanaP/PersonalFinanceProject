namespace PersonalFinanceProject.Communication.Message.TransactionType.Responses
{
    public record TransactionTypeGetListResponse
    {
        public IEnumerable<TransactionTypeResponseItem>? TransactionTypes { get; set; }

        public TransactionTypeGetListResponse()
        {
            TransactionTypes = null;
        }
    }
}