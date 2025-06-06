

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Badir.Service;

namespace Badir.Controller;

[ApiController]
[Route("api/[Controller]")]
public class CommentLikeController(IReplayCommentLikeService service) : BaseController
{
    [HttpPost ]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] ReplayCommentLikeForm form) => Ok(await service.LikeUnlikeReplayComment(form, Id));
}