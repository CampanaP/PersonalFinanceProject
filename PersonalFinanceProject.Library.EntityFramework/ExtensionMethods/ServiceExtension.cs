using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PersonalFinanceProject.Library.EntityFramework.ExtensionMethods
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDbContext<GenericDbContext<T>(options => options.UseNpgsql(configuration.GetConnectionString("SupabaseDB")));

            return services;
        }
    }
}
