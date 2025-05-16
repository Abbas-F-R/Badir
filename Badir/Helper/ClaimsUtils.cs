namespace Badir.Helper;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public class ClaimsUtils
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ClaimsUtils(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int Id => int.TryParse(GetClaim("Id"), out var id) ? id : -1;
    public string UserName => GetClaim(ClaimTypes.Name) ?? "";
    public string Role => GetClaim("Role");

    public Guid? ParentId
    {
        get
        {
            var idString = GetClaim("ParentId");
            return Guid.TryParse(idString, out var guid) ? guid : null;
        }
    }

    private string GetClaim(string claimName)
    {
        var claims = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
        var claim = claims?.Claims.FirstOrDefault(c =>
            string.Equals(c.Type, claimName, StringComparison.OrdinalIgnoreCase) &&
            !string.Equals(c.Value, "null", StringComparison.OrdinalIgnoreCase));

        return claim?.Value?.Replace("\"", "") ?? "";
    }
}

