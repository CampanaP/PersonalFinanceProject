using Microsoft.AspNetCore.Identity;

namespace PersonalFinanceProject.Library.Identity.Interfaces.Repositories
{
    public interface IIdentityUserRepository
    {
        Task AddToRole(IdentityUser user, string role);

        Task<bool> Create(IdentityUser user, string password);
    }
}