using System.Threading.Tasks;
using Badir.Service.TopicService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Badir.Controller;

[ApiController]
[Route("api/[Controller]")]
public class TopicController(ITopicService service) : BaseController
{
    [HttpPost]
    [Authorize(Roles = "Admin ")]
    public async Task<ActionResult<TopicDto>> Add([FromBody] TopicForm form ) => Ok(await service.Add(form, Id, UserName));
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<Response<TopicResponse>>> GetAll([FromQuery] TopicFilter filter) => Ok(await service.GetAll(filter), filter.PageNumber, filter.PageSize);
    [HttpPut("Users")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<TopicDto>> Update([FromBody] TopicUpdate update ) => Ok(await service.Update(update, Id, UserName));
}