using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalFinanceProject.Library.Identity.DbContexts;
using PersonalFinanceProject.Library.Identity.Settings;
using System.Text;

namespace PersonalFinanceProject.Library.Identity.Extensions
{
    public static class IdentityExtension
    {
        public static IHostApplicationBuilder ConfigureIdentity(this IHostApplicationBuilder builder, IConfiguration configuration)
        {
            JwtSetting? setting = configuration.Get<JwtSetting>();
            if (setting is null || string.IsNullOrWhiteSpace(setting.SecurityKey))
            {
                throw new Exception("Authentication is not correct configurated");
            }

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<CustomIdentityDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequiredLength = 12;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            //builder.Services.AddAuthentication(options =>
            //{
            //    //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.SecurityKey)),
            //        ValidateAudience = setting.ValidateAudience,
            //        ValidateIssuer = setting.ValidateIssuer,
            //        ValidateLifetime = setting.ValidateLifetime
            //    };
            //});

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ReadRevenueSource", policy => policy.RequireRole("Administrator", "Guest"));
                options.AddPolicy("WriteRevenueSource", policy => policy.RequireRole("Administrator", "Guest"));
                options.AddPolicy("DeleteRevenueSource", policy => policy.RequireRole("Administrator", "Guest"));

                options.AddPolicy("ReadTransactionCategory", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("WriteTransactionCategory", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteTransactionCategory", policy => policy.RequireRole("Administrator"));

                options.AddPolicy("ReadTransactionType", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("WriteTransactionType", policy => policy.RequireRole("Administrator"));
                options.AddPolicy("DeleteTransactionType", policy => policy.RequireRole("Administrator"));

                options.AddPolicy("ReadTransaction", policy => policy.RequireRole("Administrator", "Guest"));
                options.AddPolicy("WriteTransaction", policy => policy.RequireRole("Administrator", "Guest"));
                options.AddPolicy("DeleteTransaction", policy => policy.RequireRole("Administrator", "Guest"));

                options.AddPolicy("ReadUser", policy => policy.RequireRole("Administrator", "Guest"));
                options.AddPolicy("WriteUser", policy => policy.RequireRole("Administrator", "Guest"));
                options.AddPolicy("DeleteUser", policy => policy.RequireRole("Administrator", "Guest"));

                options.AddPolicy("ReadRole", policy => policy.RequireRole("Administrator", "Guest"));
            });

            return builder;
        }

        public static WebApplication UseIdentity(this WebApplication webApplication)
        {
            webApplication.UseAuthentication();
            webApplication.UseAuthorization();

            return webApplication;
        }
    }
}