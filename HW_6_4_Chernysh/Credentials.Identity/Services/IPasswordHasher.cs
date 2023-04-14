using System.Security.Cryptography;
using System.Text;

namespace Credentials.Identity.Services;

public interface IPasswordHasher
{
    public string Hash(string password);
}
