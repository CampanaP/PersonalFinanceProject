using FluentValidation;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.Transaction
{
    public class TransactionAddValidator : AbstractValidator<TransactionAddRequest>
    {
        public TransactionAddValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty();

            RuleFor(t => t.Amount)
                .NotEmpty();

            RuleFor(t => t.CategoryId)
                .NotEmpty();

            RuleFor(t => t.TypeId)
                .NotEmpty();

            RuleFor(t => t.SourceId)
                .NotEmpty();

            RuleFor(t => t.CreateDate)
                .NotEmpty();

            RuleFor(t => t.UpdateDate)
                .NotEmpty();
        }
    }
}