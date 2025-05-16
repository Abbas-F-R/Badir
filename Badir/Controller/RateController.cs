using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;

[ApiController]
[Route("api/[Controller]")]
public class RateController(IRateService service) : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<RateDto>> Add([FromBody] RateForm form) => Ok(await service.Add(form));

}