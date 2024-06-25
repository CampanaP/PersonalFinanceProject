using Microsoft.AspNetCore.Identity;
using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.Identity.Interfaces.Repositories;
using PersonalFinanceProject.Library.Logger.Interfaces.Services;

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

        public async Task AddToRole(IdentityUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<bool> Create(IdentityUser user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (result.Errors.Any())
            {
                foreach (IdentityError error in result.Errors)
                {
                    _loggerService.Error(error.Description);
                }
            }

            return result.Succeeded;
        }
    }
}