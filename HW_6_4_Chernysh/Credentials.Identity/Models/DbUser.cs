namespace Credentials.Identity.Models;

public sealed class DbUser
{
    public string Id { get; set; }

    public string[] Roles { get; set; }
    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public DateTime CreatedUtc { get; set; }
}
