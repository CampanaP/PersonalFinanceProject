using FluentValidation;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;

namespace PersonalFinanceProject.Business.Wallet.Validators.RevenueSource
{
    public class RevenueSourceUpdateValidator : AbstractValidator<RevenueSourceUpdateRequest>
    {
        public RevenueSourceUpdateValidator()
        {
            RuleFor(rs => rs.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(rs => rs.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(rs => rs.UserId)
                .NotNull()
                .NotEmpty();
        }
    }
}