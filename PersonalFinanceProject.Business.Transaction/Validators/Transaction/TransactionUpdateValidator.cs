using FluentValidation;
using PersonalFinanceProject.Communication.Message.Transaction.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.Transaction
{
    public class TransactionUpdateValidator : AbstractValidator<TransactionUpdateByIdRequest>
    {
        public TransactionUpdateValidator()
        {
            RuleFor(t => t.Id)
                .NotEmpty();

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