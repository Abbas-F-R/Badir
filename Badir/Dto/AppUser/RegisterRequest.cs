using System.ComponentModel.DataAnnotations;

namespace Badir.Dto.AppUser;

public class RegisterRequest
{
    public required string Name { get; set; }

    public required string Username { get; set; }

    public required string Password { get; set; }
    public required Role Role { get; set; }
}