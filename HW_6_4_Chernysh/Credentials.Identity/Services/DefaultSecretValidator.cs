using IdentityServer4.Models;
using IdentityServer4.Validation;

namespace Credentials.Identity.Services;

internal sealed class DefaultSecretValidator : ISecretValidator
{
    private readonly IPasswordHasher _passwordHasher;

    public DefaultSecretValidator(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public Task<SecretValidationResult> ValidateAsync(IEnumerable<Secret> secrets, ParsedSecret parsedSecret)
    {
        Console.WriteLine("2 - DefaultSecretValidator::ValidateAsync");

        return parsedSecret.Credential is null
            ? Task.FromResult(
                new SecretValidationResult { Success = false })
            
            : Task.FromResult(
                new SecretValidationResult
                {
                    Success = secrets.FirstOrDefault(secret =>
                        string.Equals(
                            _passwordHasher.Hash(parsedSecret.Credential.ToString()),
                            secret.Value.ToString(), StringComparison.Ordinal)) != null
                });
    }
}
