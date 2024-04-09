using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionCategory
{
    public class TransactionCategoryAddValidator : AbstractValidator<TransactionCategoryAddRequest>
    {
        public TransactionCategoryAddValidator()
        {
            RuleFor(tc => tc.Name).NotNull();
            RuleFor(tc => tc.Name).NotEmpty();
            RuleFor(tc => tc.Name).NotEqual(" ");
        }
    }
}