using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionCategory
{
    public class TransactionCategoryUpdateValidator : AbstractValidator<TransactionCategoryUpdateRequest>
    {
        public TransactionCategoryUpdateValidator()
        {
            RuleFor(tc => tc.Id).NotNull();
            RuleFor(tc => tc.Id).NotEqual(default(int));

            RuleFor(tc => tc.Name).NotNull();
            RuleFor(tc => tc.Name).NotEmpty();
            RuleFor(tc => tc.Name).NotEqual(" ");
        }
    }
}