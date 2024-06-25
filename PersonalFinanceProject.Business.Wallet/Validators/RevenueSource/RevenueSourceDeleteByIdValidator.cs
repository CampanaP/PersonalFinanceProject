using FluentValidation;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;

namespace PersonalFinanceProject.Business.Wallet.Validators.RevenueSource
{
    public class RevenueSourceDeleteByIdValidator : AbstractValidator<RevenueSourceDeleteByIdRequest>
    {
        public RevenueSourceDeleteByIdValidator()
        {
            RuleFor(rs => rs.Id)
                .NotEmpty();
        }
    }
}