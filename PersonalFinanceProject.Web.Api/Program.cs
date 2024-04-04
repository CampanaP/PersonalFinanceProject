﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceProject.Business.Transaction.DbContexts;
using PersonalFinanceProject.Infrastructure.DependencyInjection.ExtensionMethods;
using PersonalFinanceProject.Infrastructure.Logger.ExtensionMethods;
using PersonalFinanceProject.Infrastructure.Logger.Interfaces.Services;
using Wolverine;
using Wolverine.Http;

namespace PersonalFinanceProject.Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Host.UseWolverine(opts =>
            {
                opts.Discovery.IncludeAssembly(typeof(Business.Transaction.Endpoints.TransactionCategoryEndpoint).Assembly);
            });

            // Infrastructure.Logger
            builder.AddLogger(builder.Configuration);

            // Infrastructure.DependencyInjection
            builder.Services.AddFromAttributes();

            // Business.Transaction
            builder.Services.AddDbContext<TransactionDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseDB")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpClient();
            builder.Services.AddSwaggerGen();

            WebApplication app = builder.Build();

            // Infrastructure.DependencyInjection
            app.AddEndpoints();

            app.MapWolverineEndpoints();

            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    IExceptionHandlerPathFeature? exceptionContext = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionContext is not null)
                    {
                        ILoggerService? loggerService = context.RequestServices.GetService<ILoggerService>();
                        if (loggerService is not null)
                        {
                            loggerService.Fatal("Unhandled exception was thrown", exception: exceptionContext.Error);
                        }
                    }

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

            app.Run();
        }
    }
}