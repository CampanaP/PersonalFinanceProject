using Microsoft.Extensions.DependencyInjection;

namespace PersonalFinanceProject.Infrastructure.DependencyInjection.Interfaces
{
    public interface IEndpoint
    {
        void AddEndpoints(IServiceCollection app);
    }
}