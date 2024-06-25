namespace PersonalFinanceProject.Library.Identity.Settings
{
    internal class JwtSetting
    {
        public int? ExpiryInMinutes { get; set; }

        public string? SecurityKey { get; set; }

        public bool ValidateAudience { get; set; }

        public bool ValidateIssuer { get; set; }

        public bool ValidateLifetime { get; set; }
    }
}