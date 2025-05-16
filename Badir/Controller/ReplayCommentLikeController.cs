using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactNative.Service.CommentLikeService;

namespace ReactNative.Controller;
[ApiController]
[Route("api/[Controller]")]
public class ReplayCommentLikeController(ICommentLikeService service) : BaseController
{
    [HttpPost ]
    [Authorize]
    public async Task<IActionResult> Add([FromBody] CommentLikeForm form) => Ok(await service.LikeUnlikeComment(form, Id));
    
}