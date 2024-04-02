using System.Diagnostics.CodeAnalysis;

namespace PersonalFinanceProject.Business.Identity.Messages.Responses
{
    public class LoginResponse
    {
        public string? ErrorMessage { get; set; }

        public required bool IsAuthSuccessful { get; set; }

        public string? Token { get; set; }

        [SetsRequiredMembers]
        public LoginResponse(string? errorMessage, bool isAuthSuccessful, string? token)
        {
            ErrorMessage = errorMessage;
            IsAuthSuccessful = isAuthSuccessful;
            Token = token;
        }
    }
}