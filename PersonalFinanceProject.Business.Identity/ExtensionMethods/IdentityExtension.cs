using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PersonalFinanceProject.Business.Identities.Settings;
using System.Text;

namespace PersonalFinanceProject.Business.Identities.ExtensionMethods
{
    public static class IdentityExtension
    {
        public static IHostApplicationBuilder ConfigureIdentity(this IHostApplicationBuilder builder, IConfiguration configuration)
        {
            JwtSetting? setting = configuration.Get<JwtSetting>();
            if (setting is null || string.IsNullOrWhiteSpace(setting.SecurityKey) || string.IsNullOrWhiteSpace(setting.ValidAudience) || string.IsNullOrWhiteSpace(setting.ValidIssuer))
            {
                throw new Exception("Authentication is not correct configurated");
            }

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true);

            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequiredLength = 12;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(setting.SecurityKey)),
                    ValidAudience = setting.ValidAudience,
                    ValidIssuer = setting.ValidIssuer,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                };
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