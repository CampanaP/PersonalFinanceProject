namespace PersonalFinanceProject.Infrastructure.Logger.Settings
{
    internal class LoggerSettings
    {
        public string? FilePath { get; set; }

        public string? RollingInterval { get; set; }

        public string? OutputTemplate { get; set; }
    }
}