﻿using FluentValidation;
using PersonalFinanceProject.Communication.Message.TransactionCategory.Requests;

namespace PersonalFinanceProject.Business.Transaction.Validators.TransactionCategory
{
    public class TransactionCategoryUpdateValidator : AbstractValidator<TransactionCategoryUpdateByIdRequest>
    {
        public TransactionCategoryUpdateValidator()
        {
            RuleFor(tc => tc.Id)
                .NotEmpty();

            RuleFor(tc => tc.Name)
                .NotEmpty();
        }
    }
}