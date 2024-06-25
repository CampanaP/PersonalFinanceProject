using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using PersonalFinanceProject.Library.Logger.Settings;
using Serilog;

namespace PersonalFinanceProject.Library.Logger.Extensions
{
    public static class LoggerExtension
    {
        public static IHostApplicationBuilder AddLogger(this IHostApplicationBuilder builder, IConfiguration configuration)
        {
            LoggerSetting? setting = configuration.GetSection("LoggerSetting").Get<LoggerSetting>();
            if (setting is null || string.IsNullOrWhiteSpace(setting.FilePath) || string.IsNullOrWhiteSpace(setting.RollingInterval) || string.IsNullOrWhiteSpace(setting.OutputTemplate))
            {
                throw new Exception("Logger is not correct configurated");
            }

            bool parseResult = Enum.TryParse(setting.RollingInterval, out RollingInterval rollingIntervalValue);
            if (!parseResult)
            {
                throw new Exception("Logger is not correct configurated");
            }

            Serilog.Core.Logger? logger = new LoggerConfiguration()
                .WriteTo.File(setting.FilePath,
                    rollingInterval: rollingIntervalValue,
                    outputTemplate: setting.OutputTemplate)
                .CreateLogger();

            builder.Logging.AddSerilog(logger);

            return builder;
        }
    }
}