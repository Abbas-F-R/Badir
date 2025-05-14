
using System.Security.Claims;

namespace ReactNative.Service.AuthService;

public interface IJwtService
{
    // string CreateToken(User user, int? time);
    Task<(Auth?, string? error)> Register(UserForm request);
    // Task<(Auth?, string? error)> Register(UserRegisterForm request, string role);
    // Task<(Auth?, string? error)> ManagerRegister(UserManagerForm request);
    Task<(Auth?, string? error)> Login(LoginRequest request);
    Task<(Auth?, string?)> LoginWithGoogle(ClaimsPrincipal principal);

}