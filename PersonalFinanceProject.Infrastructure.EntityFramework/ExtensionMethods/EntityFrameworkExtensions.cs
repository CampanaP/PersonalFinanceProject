using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalFinanceProject.Infrastructure.EntityFramework.ExtensionMethods
{
    public static class EntityFrameworkExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenericDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("SupabaseDB")));

            return services;
        }
    }
}