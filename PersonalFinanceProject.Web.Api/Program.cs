﻿using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transactions.DbContexts;
using PersonalFinanceProject.Infrastructure.DependencyInjection.ExtensionMethods;
using Wolverine;
using Wolverine.Http;

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

            // Infrastructure.DependencyInjection
            builder.Services.AddFromAttributes();

            // Business.Transaction
            builder.Services.AddDbContext<TransactionDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

            builder.Host.UseWolverine();

            WebApplication app = builder.Build();

            // Infrastructure.DependencyInjection
            app.AddEndpoints();

            app.MapWolverineEndpoints();

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

            app.MapWolverineEndpoints();
            app.Run();
        }
    }
}