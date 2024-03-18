using PersonalFinanceProject.Web.Api.Interfaces;

namespace PersonalFinanceProject.Web.Api.ExtensionMethods
{
    public static class ApiExtensions
    {
        public static WebApplication MapEndpoints(this WebApplication app)
        {
            System.Reflection.Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            IOrderedEnumerable<Type> classes = assemblies.Distinct().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).OrderBy(x => x.FullName);

            foreach (Type @class in classes)
            {
                IEndpoint? instance = Activator.CreateInstance(@class) as IEndpoint;
                instance?.MapEndpoints(app);
            }

            return app;
        }
    }
}