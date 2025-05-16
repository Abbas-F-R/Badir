using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;


[ApiController]
[Route("api/[Controller]")]
public class CommentController(ICommentService service) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CommentDto>> Add([FromBody] CommentForm form) => Ok(await service.Add(form));

    [HttpGet("{id}")]
    public async Task<ActionResult<CommentDto>> Get(int id) => Ok(await service.Get(id, Id));

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<CommentDto>> Update([FromBody] CommentUpdate update, int id) => Ok(await service.Update(update, id));

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<CommentDto>> Delete(int id) => Ok(await service.Delete(id));

    [HttpGet]
    public async Task<ActionResult<Response<CommentResponse>>> GetAll([FromQuery] CommentFilter filter) => Ok(await service.GatAll(filter), filter.PageNumber, filter.PageSize);

}