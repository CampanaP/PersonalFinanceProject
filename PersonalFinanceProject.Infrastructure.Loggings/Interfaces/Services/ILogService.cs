using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Events;

namespace PersonalFinanceProject.Infrastructure.Loggings.Interfaces.Services
{
    public interface ILogService
    {
        IServiceCollection Configure(WebApplicationBuilder builder);
        void Write(LogEventLevel level, string message, Exception? exception = null);
    }
}