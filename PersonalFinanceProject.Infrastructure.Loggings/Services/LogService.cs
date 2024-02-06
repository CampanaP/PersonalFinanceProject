using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Infrastructure.Loggings.Interfaces.Services;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace PersonalFinanceProject.Infrastructure.Loggings.Services
{
    public class LogService : ILogService
    {
        private IConfiguration _configuration;

        public LogService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceCollection Configure(WebApplicationBuilder builder)
        {
            string? loggerFilePath = _configuration.GetValue<string>("Logger:FilePath");
            string? loggerRollingInterval = _configuration.GetValue<string>("Logger:RollingInterval");
            string? loggerOutputTemplate = _configuration.GetValue<string>("Logger:OutputTemplate");

            if (string.IsNullOrWhiteSpace(loggerFilePath) || string.IsNullOrWhiteSpace(loggerRollingInterval) || string.IsNullOrWhiteSpace(loggerOutputTemplate))
            {
                throw new Exception("Logger is not correct configurated");
            }

            bool parseResult = Enum.TryParse(loggerRollingInterval, out RollingInterval loggerRollingIntervalValue);
            if (!parseResult)
            {
                throw new Exception("Logger is not correct configurated");
            }

            Logger? logger = new LoggerConfiguration()
                .WriteTo.File(loggerFilePath,
                    rollingInterval: loggerRollingIntervalValue,
                    outputTemplate: loggerOutputTemplate)
                .CreateLogger();

            builder.Logging.AddSerilog(logger);

            return builder.Services;
        }

        public void Write(LogEventLevel level, string message, Exception? exception = null)
        {
            Dictionary<LogEventLevel, Action> logEventLevels = new Dictionary<LogEventLevel, Action>
            {
                { LogEventLevel.Verbose, () => Log.Verbose(exception, message) },
                { LogEventLevel.Debug, () => Log.Debug(message, exception) },
                { LogEventLevel.Information, () => Log.Information(message, exception) },
                { LogEventLevel.Warning, () => Log.Warning(message, exception) },
                { LogEventLevel.Error, () => Log.Error(message, exception) },
                { LogEventLevel.Fatal, () => Log.Fatal(message, exception) }
            };

            logEventLevels[level]();
        }
    }
}