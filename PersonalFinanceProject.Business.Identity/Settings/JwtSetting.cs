namespace PersonalFinanceProject.Business.Identity.Settings
{
    internal class JwtSetting
    {
        public int? ExpiryInMinutes { get; set; }

        public string? SecurityKey { get; set; }

        public string? ValidAudience { get; set; }

        public string? ValidIssuer { get; set; }
    }
}