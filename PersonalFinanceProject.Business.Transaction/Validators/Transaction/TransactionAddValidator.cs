using FluentValidation;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.Transaction
{
    public class TransactionAddValidator : AbstractValidator<TransactionAddRequest>
    {
        public TransactionAddValidator()
        {
            RuleFor(t => t.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.Amount)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.CategoryId)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.TypeId)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.SourceId)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.CreateDate)
                .NotNull()
                .NotEmpty();

            RuleFor(t => t.UpdateDate)
                .NotNull()
                .NotEmpty();
        }
    }
}