using FluentValidation;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionType
{
    public class TransactionUpdateValidator : AbstractValidator<TransactionUpdateByIdRequest>
    {
        public TransactionUpdateValidator()
        {
            RuleFor(t => t.Id)
                .NotNull()
                .NotEmpty();

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