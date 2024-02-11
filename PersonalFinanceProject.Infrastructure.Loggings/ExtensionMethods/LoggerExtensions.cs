using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using PersonalFinanceProject.Infrastructure.Loggings.Settings;
using Serilog;
using Serilog.Core;

namespace PersonalFinanceProject.Infrastructure.Loggings.ExtensionMethods
{
    public static class LoggerExtensions
    {
        public static WebApplicationBuilder ConfigureLogger(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            LoggerSettings? settings = configuration.Get<LoggerSettings>();

            if (settings is null || string.IsNullOrWhiteSpace(settings.FilePath) || string.IsNullOrWhiteSpace(settings.RollingInterval) || string.IsNullOrWhiteSpace(settings.OutputTemplate))
            {
                throw new Exception("Logger is not correct configurated");
            }

            bool parseResult = Enum.TryParse(settings.RollingInterval, out RollingInterval rollingIntervalValue);
            if (!parseResult)
            {
                throw new Exception("Logger is not correct configurated");
            }

            Logger? logger = new LoggerConfiguration()
                .WriteTo.File(settings.FilePath,
                    rollingInterval: rollingIntervalValue,
                    outputTemplate: settings.OutputTemplate)
                .CreateLogger();

            builder.Logging.AddSerilog(logger);

            return builder;
        }
    }
}