using PersonalFinanceProject.Web.Api.ExtensionMethods;

namespace PersonalFinanceProject.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpClient();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync("An error was found in the request.");
                });
            });

            if (!builder.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapEndpoints();
            app.Run();
        }
    }
}