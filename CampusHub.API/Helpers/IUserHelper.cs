using Microsoft.AspNetCore.Identity;
using CampusHub.Shared.DTOs;
using CampusHub.Shared.Entities;

namespace CampusHub.API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);



        Task<SignInResult> LoginAsync(LoginDTO model);

        Task LogoutAsync();

    }
}