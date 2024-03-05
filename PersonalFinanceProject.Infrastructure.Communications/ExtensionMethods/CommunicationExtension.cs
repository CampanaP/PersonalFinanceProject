using Microsoft.AspNetCore.Builder;

namespace PersonalFinanceProject.Infrastructure.Communication.ExtensionMethods
{
    public static class CommunicationExtension
    {
        public static WebApplicationBuilder ConfigureWolverine(this WebApplicationBuilder builder)
        {
            builder.Host.UseWolverine();

            return builder;
        }
    }
}