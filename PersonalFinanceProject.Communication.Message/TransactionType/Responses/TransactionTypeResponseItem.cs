namespace PersonalFinanceProject.Communication.Message.TransactionType.Responses
{
    public record TransactionTypeResponseItem
    {
        public required int Id { get; set; }

        public required string Name { get; set; }
    }
}