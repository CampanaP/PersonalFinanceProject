using Microsoft.AspNetCore.Builder;

namespace PersonalFinanceProject.Infrastructure.DependencyInjection.Interfaces
{
    public interface IEndpoint
    {
        void AddEndpoints(WebApplication app);
    }
}