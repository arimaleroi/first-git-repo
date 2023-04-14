using Credentials.Identity.Models;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Credentials.Identity.Services;

internal sealed class CredentialsStore : IClientStore
{
    private readonly IUserRepository _userRepository;

    public CredentialsStore(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Client> FindClientByIdAsync(string clientId)
    {
        //First Call.
        Console.WriteLine($"1 - CredentialsStore::FindClientByIdAsync - ClientId: {clientId}");

        DbUser user = await _userRepository.GetUserByNameAsync(clientId);

        var roles = new List<ClientClaim>();

        if(user.Roles.Contains("Admin"))
        {
            roles.Add(new ClientClaim("roles", "Admin"));
            roles.Add(new ClientClaim("roles", "Customer"));
        }

        return
            new Client
            {
                ClientId = user.Id,
                ClientSecrets =
                {
                     new Secret { Value = user.PasswordHash } // needed for token validation in DefaultSecretValidator.
                },
                Claims = roles.ToArray(),
                ClientClaimsPrefix = string.Empty, // override default prefix _client.
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes = { Scopes.UpdateUser, Scopes.GetUser, "test-no-added" } // Add only scopes defined in the array in AppScope in the Program.cs -> GetApiScope.
            };
    }
}
