using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactNative.Controller;

[ApiController]
[Route("api/[Controller]")]
public class PostController(IPostService service) : BaseController
{
    [HttpPost]
    public async Task<ActionResult<PostDto>> Add([FromBody] PostForm form) => Ok(await service.Add(form));
    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> Get(int id) => Ok(await service.Get(id, Id));
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<PostDto>> Update([FromBody] PostUpdate update, int id) => Ok(await service.Update(update, id));
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<PostDto>> Delete(int id) => Ok(await service.Delete(id));
    [HttpGet]   
    public async Task<ActionResult<Response<PostResponse>>> GetAll([FromQuery] PostFilter filter) => Ok(await service.GetAll(filter), filter.PageNumber, filter.PageSize);
    [HttpPut("IncrementClickCount/{id}")]
    public async Task<ActionResult<PostDto>> IncrementClickCount( int id) => Ok(await service.IncrementClickCount( id ));

}