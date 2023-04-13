using System.Security.Cryptography;
using System.Text;

namespace Credentials.Identity.Services;

public sealed class SimplePasswordHasher : IPasswordHasher
{
    public string Hash(string password)
    {
        // Add salt field also.
        using var sha256 = SHA256.Create();
        var sha256Bytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(password));
        return Encoding.Unicode.GetString(sha256Bytes);
    }
}
