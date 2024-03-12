using PersonalFinanceProject.Infrastructure.Logger.Interfaces.Services;
using Serilog;

namespace PersonalFinanceProject.Infrastructure.Logger.Services
{
    internal class LoggerService : ILoggerService
    {
        public LoggerService()
        {
        }

        public void Debug(string message, object[]? messageObjectValues = null, Exception? exception = null)
        {
            Log.Debug(message, messageObjectValues, exception);
        }

        public void Error(string message, object[]? messageObjectValues = null, Exception? exception = null)
        {
            Log.Error(message, messageObjectValues, exception);
        }

        public void Fatal(string message, object[]? messageObjectValues = null, Exception? exception = null)
        {
            Log.Fatal(message, messageObjectValues, exception);
        }

        public void Information(string message, object[]? messageObjectValues = null, Exception? exception = null)
        {
            Log.Information(message, messageObjectValues, exception);
        }

        public void Verbose(string message, object[]? messageObjectValues = null, Exception? exception = null)
        {
            Log.Verbose(message, messageObjectValues, exception);
        }

        public void Warning(string message, object[]? messageObjectValues = null, Exception? exception = null)
        {
            Log.Warning(message, messageObjectValues, exception);
        }
    }
}