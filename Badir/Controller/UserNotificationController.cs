using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;
[ApiController]
[Route("api/[Controller]")]
public class UserNotificationController(IUserNotificationService service) : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<UserNotificationDto>> Add([FromBody] UserNotificationForm form ) =>
        Ok(await service.Add(form, Id));
}