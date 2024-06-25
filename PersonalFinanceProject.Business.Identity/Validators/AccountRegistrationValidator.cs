using FluentValidation;
using PersonalFinanceProject.Communication.Message.Account.Requests;

namespace PersonalFinanceProject.Business.Account.Validators
{
    internal class AccountRegistrationValidator : AbstractValidator<AccountRegistrationRequest>
    {
        public AccountRegistrationValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(a => a.Password)
                .NotEmpty();

            RuleFor(a => a.ConfirmPassword)
                .NotEmpty()
                .Equal(a => a.Password);
        }
    }
}