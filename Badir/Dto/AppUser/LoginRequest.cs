using System.ComponentModel.DataAnnotations;

namespace Badir.Dto.AppUser;

public class LoginRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }

}