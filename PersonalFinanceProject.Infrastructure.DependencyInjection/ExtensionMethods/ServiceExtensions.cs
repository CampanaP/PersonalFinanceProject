using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Infrastructure.DependencyInjection.Attributes;
using Scrutor;

namespace PersonalFinanceProject.Infrastructure.DependencyInjection.ExtensionMethods
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddFromAttributes(this IServiceCollection services)
        {
            return services
                .Scan(scan => scan
                    .FromApplicationDependencies()

                    //Transient classes
                    .AddClasses(@class => @class.WithAttribute<TransientLifetimeAttribute>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsSelfWithInterfaces()
                    .WithTransientLifetime()

                    //Scoped classes
                    .AddClasses(@class => @class.WithAttribute<ScopedLifetimeAttribute>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime()

                    //Singleton classes
                    .AddClasses(@class => @class.WithAttribute<SingletonLifetimeAttribute>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsSelfWithInterfaces()
                    .WithSingletonLifetime());
        }
    }
}