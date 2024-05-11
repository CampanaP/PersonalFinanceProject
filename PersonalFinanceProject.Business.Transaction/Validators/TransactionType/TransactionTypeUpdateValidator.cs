﻿using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionType.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionType
{
    public class TransactionTypeUpdateValidator : AbstractValidator<TransactionTypeUpdateByIdRequest>
    {
        public TransactionTypeUpdateValidator()
        {
            RuleFor(tt => tt.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(tt => tt.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}