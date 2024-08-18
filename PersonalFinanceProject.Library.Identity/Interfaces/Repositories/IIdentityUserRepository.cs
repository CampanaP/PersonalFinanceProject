using PersonalFinanceProject.Library.Identity.Entities;

namespace PersonalFinanceProject.Library.Identity.Interfaces.Repositories
{
    public interface IIdentityUserRepository
    {
        Task<bool> AddToRole(User user, string role);

        Task<bool> Create(User user, string password);
    }
}