using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionType
{
    public class TransactionTypeUpdateValidator : AbstractValidator<TransactionTypeUpdateByIdRequest>
    {
        public TransactionTypeUpdateValidator()
        {
            RuleFor(tt => tt.Id)
                .NotEmpty();

            RuleFor(tt => tt.Name)
                .NotEmpty();
        }
    }
}