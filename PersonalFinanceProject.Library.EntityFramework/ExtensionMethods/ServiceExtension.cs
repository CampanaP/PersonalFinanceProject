using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Library.EntityFramework.DbContexts;

namespace PersonalFinanceProject.Library.EntityFramework.ExtensionMethods
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GenericDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("SupabaseDB")));

            return services;
        }
    }
}
