using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactNative.Controller;

[ApiController]
[Route("api/[Controller]")]
public class HashtagController(IHashtagService service) : BaseController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<HashtagDto>> Add([FromBody] HashtagForm form) => Ok(await service.Add(form));
  
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<HashtagDto>> Update([FromBody] HashtagUpdate update, int id) => Ok(await service.Update(update, id));

    [HttpGet] 
    public async Task<ActionResult<Response<HashtagResponse>>> GetAll([FromQuery] HashtagFilter filter) => Ok(await service.GatAll(filter), filter.PageNumber, filter.PageSize);
  
}