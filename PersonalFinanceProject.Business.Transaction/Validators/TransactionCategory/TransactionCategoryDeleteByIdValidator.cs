using FluentValidation;
using PersonalFinanceProject.Business.Transaction.Messages.TransactionCategory.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionCategory
{
    public class TransactionCategoryDeleteByIdValidator : AbstractValidator<TransactionCategoryDeleteByIdRequestMessage>
    {
        public TransactionCategoryDeleteByIdValidator()
        {
            RuleFor(tc => tc.Id).NotNull();
            RuleFor(tc => tc.Id).NotEqual(default(int));
        }
    }
}