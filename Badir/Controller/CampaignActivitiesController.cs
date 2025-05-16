using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;


[ApiController]
[Route("api/[Controller]")]
public class CampaignActivitiesController(ICampaignActivitiesService service) : BaseController
{
    [HttpPost ]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] CampaignActivitiesForm form) => Ok(await service.Add(form));



}