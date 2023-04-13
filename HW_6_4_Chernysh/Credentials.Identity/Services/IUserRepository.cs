using Credentials.Identity.Models;

namespace Credentials.Identity.Services
{
    public interface IUserRepository
    {
        /// <summary>
        ///     Adds user.
        /// </summary>
        /// <param name="dbUser">DbUser.</param>
        public Task AddUserAsync(DbUser dbUser);

        public Task<DbUser> GetUserByNameAsync(string userName);
    }
}
