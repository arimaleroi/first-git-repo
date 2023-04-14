using Credentials.Identity.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Credentials.Identity.Services;

public sealed class MemoryUserRepository : IUserRepository
{

    private readonly IMemoryCache _userMemoryCache;

    public MemoryUserRepository(IMemoryCache userMemoryCache)
    {
        _userMemoryCache = userMemoryCache;
        AddUserAsync(new DbUser()
        {
            Id = Guid.NewGuid().ToString(),
            PasswordHash = "汱ĉ홠牿⭖틆㹲鯧찚�牼ӆ�ꚻ䴻",
            UserName = "AdminCustomerUser",
            Roles = new[] { "Admin", "Customer" },
            CreatedUtc = DateTime.Now,
        });

        AddUserAsync(new DbUser()
        {
            Id = Guid.NewGuid().ToString(),
            PasswordHash = "휠쩩ᬉ瑯�⊱珎�홷ꑢ︔ఇ芉硲",
            UserName = "CustomerUser",
            Roles = new[] { "Customer" },
            CreatedUtc = DateTime.Now,
        });
    }

    public Task AddUserAsync(DbUser dbUser)
    {
        _userMemoryCache.Set(dbUser.UserName, dbUser);
        return Task.CompletedTask;
    }

    public Task<DbUser> GetUserByNameAsync(string userName)
    {
        return Task.FromResult(_userMemoryCache.Get<DbUser>(userName));
    }
}
