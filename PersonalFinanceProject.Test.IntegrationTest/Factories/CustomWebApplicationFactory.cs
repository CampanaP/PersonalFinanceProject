using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Web.Api;

namespace PersonalFinanceProject.Test.IntegrationTest.Factories
{
    internal class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : Program
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
                {
                    ServiceDescriptor? descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<TransactionDbContext>));
                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    SqliteConnection connection = new SqliteConnection("DataSource=:memory:");

                    connection.Open();

                    services.AddDbContext<TransactionDbContext>(options =>
                    {
                        options.UseSqlite(connection)
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);
                    });
                });
        }
    }
}