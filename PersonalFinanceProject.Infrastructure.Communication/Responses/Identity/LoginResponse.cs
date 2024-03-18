namespace PersonalFinanceProject.Infrastructure.Communication.Responses.Identity
{
    public record LoginResponse
    {
        public string? ErrorMessage { get; set; }

        public required bool IsAuthSuccessful { get; set; }

        public string? Token { get; set; }
    }
}