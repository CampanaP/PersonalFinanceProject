namespace PersonalFinanceProject.Business.Transactions.Messages.Requests
{
    public class TransactionCategoryRequestMessage
    {
        public record GetByIdRequest(int id);

        public record GetListRequest();
    }
}
