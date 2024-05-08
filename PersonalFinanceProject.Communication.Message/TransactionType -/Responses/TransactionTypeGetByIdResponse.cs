namespace PersonalFinanceProject.Communication.Message.TransactionType.Responses
{
    public record TransactionTypeGetByIdResponse
    {
        public TransactionTypeResponseItem? TransactionType { get; set; }

        public TransactionTypeGetByIdResponse()
        {
            TransactionType = null;
        }
    }
}