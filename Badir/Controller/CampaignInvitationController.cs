using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;

[ApiController]
[Route("api/[Controller]")]
public class CampaignInvitationController(ICampaignInvitationService service) : BaseController
{
    [HttpPost ]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] CampaignInvitationForm form) => Ok(await service.Add(form));

    [HttpPost ("Invite/{id}")]
    [Authorize]
    public async Task<IActionResult> Invite(int id) => Ok(await service.Invitation(id, Id));
}