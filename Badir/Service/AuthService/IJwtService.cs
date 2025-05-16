
using System.Security.Claims;

namespace Badir.Service.AuthService;

public interface IJwtService
{
    Task<(Auth?, string? error)> Register(UserForm request);

    Task<(Auth?, string? error)> Login(LoginRequest request);
    Task<(Auth?, string?)> LoginWithGoogle(ClaimsPrincipal principal);
    Task<(UserDto?, string? error)> AddPermission(UserPermissionsUpdate update);


}