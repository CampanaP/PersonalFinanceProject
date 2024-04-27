using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionCategory
{
    public class TransactionCategoryDeleteByIdValidator : AbstractValidator<TransactionCategoryDeleteByIdRequest>
    {
        public TransactionCategoryDeleteByIdValidator()
        {
            RuleFor(tc => tc.Id)
                .NotNull()
                .NotEmpty();
        }
    }
}