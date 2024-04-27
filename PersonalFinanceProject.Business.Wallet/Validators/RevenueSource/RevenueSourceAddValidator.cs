using FluentValidation;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;

namespace PersonalFinanceProject.Business.Wallet.Validators.RevenueSource
{
    public class RevenueSourceAddValidator : AbstractValidator<RevenueSourceAddRequest>
    {
        public RevenueSourceAddValidator()
        {
            RuleFor(rs => rs.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(rs => rs.UserId)
                .NotNull()
                .NotEmpty();
        }
    }
}