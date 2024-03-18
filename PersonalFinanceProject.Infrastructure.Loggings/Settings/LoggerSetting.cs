namespace PersonalFinanceProject.Infrastructure.Logger.Settings
{
    internal class LoggerSetting
    {
        public string? FilePath { get; set; }

        public string? RollingInterval { get; set; }

        public string? OutputTemplate { get; set; }
    }
}