using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;

[ApiController]
[Route("api/[Controller]")]
public class PermissionsController(IPermissionService service) : BaseController
{

    [HttpGet("System")]
    public async Task<ActionResult<Response<PermissionResponse>>> GetAllSystem() =>
        Ok(await service.GatAllSystem());
}