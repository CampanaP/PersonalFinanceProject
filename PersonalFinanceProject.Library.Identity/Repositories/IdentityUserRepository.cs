using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.Identity.Entities;
using PersonalFinanceProject.Library.Identity.Interfaces.Repositories;
using PersonalFinanceProject.Library.Logger.Interfaces.Services;
using System.Security.Claims;

namespace PersonalFinanceProject.Library.Identity.Repositories
{
    [ScopedLifetime]
    internal class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly ILoggerService _loggerService;
        private readonly UserManager<IdentityUser> _userManager;

        public IdentityUserRepository(ILoggerService loggerService, UserManager<IdentityUser> userManager)
        {
            _loggerService = loggerService;
            _userManager = userManager;
        }

        public async Task<bool> AddToRole(User user, string role)
        {
            bool result = false;

            IdentityResult identityResult = await _userManager.AddToRoleAsync(user, role);
            if (identityResult.Errors.Any())
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    _loggerService.Error(error.Description);
                }
            }

            result = identityResult.Succeeded;

            return result;
        }

        public async Task<bool> Create(User user, string password)
        {
            bool result = false;

            IdentityResult identityResult = await _userManager.CreateAsync(user, password);
            if (identityResult.Errors.Any())
            {
                foreach (IdentityError error in identityResult.Errors)
                {
                    _loggerService.Error(error.Description);
                }
            }

            result = identityResult.Succeeded;

            return result;
        }

        public async Task<bool> Login(string email, string password)
        {
            bool result = false;

            IdentityUser? user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                return result;
            }

            if (!await _userManager.CheckPasswordAsync(user, password)) 
            {
                return result;
            }

            ClaimsIdentity identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            
            //await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(identity));

            //if (user != null &&
            //    await _userManager.CheckPasswordAsync(user, userModel.Password))
            //{
            //    var identity = new ClaimsIdentity(IdentityConstants.ApplicationScheme);
            //    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            //    identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            //    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme,
            //        new ClaimsPrincipal(identity));
            //    return RedirectToAction(nameof(HomeController.Index), "Home");
            //}


            return result;
        }
    }
}