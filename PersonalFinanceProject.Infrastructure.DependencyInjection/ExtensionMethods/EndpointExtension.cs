using Microsoft.AspNetCore.Builder;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Interfaces;

namespace PersonalFinanceProject.Infrastructure.DependencyInjection.ExtensionMethods
{
    public static class EndpointExtension
    {
        public static WebApplication AddEndpoints(this WebApplication app)
        {
            System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            IOrderedEnumerable<Type> classes = assemblies.Distinct().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).OrderBy(x => x.FullName);

            foreach (Type @class in classes)
            {
                IEndpoint? instance = Activator.CreateInstance(@class) as IEndpoint;
                instance?.AddEndpoints(app);
            }

            return app;
        }
    }
}