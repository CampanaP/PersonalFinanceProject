namespace PersonalFinanceProject.Business.Transaction.Messages.Requests
{
    public class TransactionCategoryRequestMessage
    {
        public record GetByIdRequest(int id);

        public record GetListRequest();
    }
}
