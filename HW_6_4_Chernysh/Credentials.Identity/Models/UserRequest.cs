using System.ComponentModel.DataAnnotations;

namespace Credentials.Identity.Models;

public sealed class UserRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string[] Roles { get; set; }

    [Required]
    public string Password { get; set; }
}
