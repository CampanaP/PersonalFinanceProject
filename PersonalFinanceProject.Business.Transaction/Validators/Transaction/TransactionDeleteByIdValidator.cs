using FluentValidation;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.Transaction
{
    public class TransactionDeleteByIdValidator : AbstractValidator<TransactionDeleteByIdRequest>
    {
        public TransactionDeleteByIdValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty();
        }
    }
}