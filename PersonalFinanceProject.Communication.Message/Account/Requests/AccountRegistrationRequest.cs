﻿namespace PersonalFinanceProject.Communication.Message.Account.Requests
{
    public class AccountRegistrationRequest
    {
        public required string Email { get; set; }

        public required string Password { get; set; }

        public required string ConfirmPassword { get; set; }
    }
}