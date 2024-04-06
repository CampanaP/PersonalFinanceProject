using FluentValidation;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionCategory
{
    public class TransactionCategoryAddValidator : AbstractValidator<TransactionCategoryAddRequestMessage>
    {
        public TransactionCategoryAddValidator()
        {
            RuleFor(tc => tc.Name).NotNull();
            RuleFor(tc => tc.Name).NotEmpty();
            RuleFor(tc => tc.Name).NotEqual(" ");
        }
    }
}