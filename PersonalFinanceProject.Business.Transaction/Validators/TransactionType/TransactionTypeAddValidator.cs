using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionType
{
    public class TransactionTypeAddValidator : AbstractValidator<TransactionTypeAddRequest>
    {
        public TransactionTypeAddValidator()
        {
            RuleFor(tt => tt.Name)
                .NotEmpty();
        }
    }
}