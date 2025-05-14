using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReactNative.Controller;

[Route("api/[Controller]")]
[ApiController]
public class UserController(IUserService service) : BaseController
{
    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> Get(int id) => Ok( await service.Get(id));
    [HttpGet]
    public async Task<ActionResult<Response<UserResponse>>> GetAll([FromQuery] UserFilter filter) => Ok(await service.GetAll(filter), filter.PageNumber, filter.PageSize);
    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete() => Ok(await service.DeleteById(Id));
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> Update([FromBody] UserUpdate update, int id) => Ok(await service.Update(id, update));
    
    [HttpPost("Follow")]
    [Authorize]
    public async Task<ActionResult> Follow([FromBody] FollowForm form) => Ok(await service.FollowUser(form, Id));
    
    [HttpGet ("Followers")]
    public async Task<ActionResult<Response<UserResponse>>> GetFollowers([FromQuery] FollowFilter filter) => Ok(await service.GetFollowers(filter), filter.PageNumber, filter.PageSize);
    [HttpGet ("Following")]
    public async Task<ActionResult<Response<UserResponse>>> GetFollowing([FromQuery] FollowFilter filter) => Ok(await service.GetFollowing(filter), filter.PageNumber, filter.PageSize);


    
    [HttpPut("Update/Permission")]
    public async Task<ActionResult> UpdatePermission([FromBody] UserPermissionsUpdate update) => 
        Ok(await service.AddPermission(update));
    [HttpPut("Remove/Permission")]
    public async Task<ActionResult<UserDto>> RemovePermission([FromBody] UserPermissionsUpdate update) =>
        Ok(await service.RemovePermission(update));
    
    

} 