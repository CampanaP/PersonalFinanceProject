using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using Scrutor;

namespace PersonalFinanceProject.Library.DependencyInjection.ExtensionMethods
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddFromAttributes(this IServiceCollection services)
        {
            return services
                .Scan(scan => scan
                    .FromApplicationDependencies()

                    //Transient classes
                    .AddClasses(@class => @class.WithAttribute<TransientLifetimeAttribute>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()

                    //Scoped classes
                    .AddClasses(@class => @class.WithAttribute<ScopedLifetimeAttribute>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()

                    //Singleton classes
                    .AddClasses(@class => @class.WithAttribute<SingletonLifetimeAttribute>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime());
        }
    }
}