using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactNative.Controller;
[ApiController]
[Route("api/[Controller]")]
public class LikeController(ILikeService service) : BaseController
{
    [HttpPost ]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] LikeForm form) => Ok(await service.LikeUnlikePost(form, Id));
}