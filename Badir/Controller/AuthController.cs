using System.Security.Claims;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;

[Route("api/[Controller]")]
[ApiController]
public class AuthController(IJwtService jwtService)  : BaseController
{
 
    [HttpPost("Register")]
    public async Task<ActionResult<Auth>> Register(UserForm request) => Ok(await jwtService.Register(request) );
    
    [HttpPost("Login")]
    public async Task<ActionResult<Auth>> Login(LoginRequest request) => Ok(await jwtService.Login(request));
    [HttpPut("Update/Permission")]
    public async Task<ActionResult<UserDto>> UpdatePermission([FromBody] UserPermissionsUpdate update) => 
        Ok(await jwtService.AddPermission(update));
    [HttpPost("google-login")]
    public async Task<IActionResult> GoogleLogin([FromBody] GoogleTokenRequest request)
    {
        var googleClient = new GoogleJsonWebSignature.ValidationSettings();

        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(request.IdToken, googleClient);

            var principal = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, payload.Email),
                new Claim(ClaimTypes.Name, payload.Name),
            }, "Google"));

            var (auth, error) = await jwtService.LoginWithGoogle(principal);

            if (error != null)
                return BadRequest(error);

            return Ok(auth);
        }
        catch (Exception ex)
        {
            return Unauthorized("Invalid Google token: " + ex.Message);
        }
    }


}