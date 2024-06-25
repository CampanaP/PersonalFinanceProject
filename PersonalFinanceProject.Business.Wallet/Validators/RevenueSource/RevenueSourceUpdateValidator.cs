using FluentValidation;
using PersonalFinanceProject.Communication.Message.RevenueSource.Requests;

namespace PersonalFinanceProject.Business.Wallet.Validators.RevenueSource
{
    public class RevenueSourceUpdateValidator : AbstractValidator<RevenueSourceUpdateByIdRequest>
    {
        public RevenueSourceUpdateValidator()
        {
            RuleFor(rs => rs.Id)
                .NotEmpty();

            RuleFor(rs => rs.Name)
                .NotEmpty();

            RuleFor(rs => rs.UserId)
                .NotEmpty();
        }
    }
}