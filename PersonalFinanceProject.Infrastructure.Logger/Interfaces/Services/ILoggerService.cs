namespace PersonalFinanceProject.Infrastructure.Logger.Interfaces.Services
{
    public interface ILoggerService
    {
        void Debug(string message, object[]? messageObjectValues = null, Exception? exception = null);

        void Error(string message, object[]? messageObjectValues = null, Exception? exception = null);

        void Fatal(string message, object[]? messageObjectValues = null, Exception? exception = null);

        void Information(string message, object[]? messageObjectValues = null, Exception? exception = null);

        void Verbose(string message, object[]? messageObjectValues = null, Exception? exception = null);

        void Warning(string message, object[]? messageObjectValues = null, Exception? exception = null);
    }
}