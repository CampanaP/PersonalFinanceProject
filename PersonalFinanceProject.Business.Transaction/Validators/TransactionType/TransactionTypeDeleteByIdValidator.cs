using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionType
{
    public class TransactionTypeDeleteByIdValidator : AbstractValidator<TransactionTypeDeleteByIdRequest>
    {
        public TransactionTypeDeleteByIdValidator()
        {
            RuleFor(tt => tt.Id)
                .NotEmpty();
        }
    }
}