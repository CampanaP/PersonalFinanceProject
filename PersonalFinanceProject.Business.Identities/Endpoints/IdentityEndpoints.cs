using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Interfaces;

namespace PersonalFinanceProject.Web.Api.Endpoints.Identity
{
    public class IdentityEndpoints : IEndpoint
    {
        public void AddEndpoints(IServiceCollection app)
        {
            //app.MapPostToWolverine<LoginRequest, LoginResponse>("api/identity/login");
        }
    }
}