using Credentials.Identity.Models;
using Credentials.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Credentials.Identity.Controllers;

[Route("users")]
public sealed class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserController(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    [HttpPost]
    public Task<IActionResult> CreateUserAsync([FromBody] [Required] UserRequest userRequest)
    {
        string userId = Guid.NewGuid().ToString();

        _userRepository.AddUserAsync(new DbUser
        {
            Id = userId,
            UserName = userRequest.UserName,
            Roles = userRequest.Roles,
            PasswordHash = _passwordHasher.Hash(userRequest.Password),
            CreatedUtc = DateTime.UtcNow
        });

        return Task.FromResult<IActionResult>(Ok(userId));
    }

    [HttpGet("{userName}")]
    public async Task<IActionResult> GetUser([FromRoute] string userName)
    {
        DbUser user = await _userRepository.GetUserByNameAsync(userName);

        return Ok(new UserResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            CreatedUtc = user.CreatedUtc
        });
    }
}
