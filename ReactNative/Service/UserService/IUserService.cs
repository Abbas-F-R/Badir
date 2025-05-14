
namespace ReactNative.Service.UserService;

public interface IUserService
{
    Task<(UserDto? data, string? error)> Get(int id);
    // Task<(UserDto? data, string? error)> UpdateProject(UserProjectUpdate update);
    Task<(List<UserResponse>? data, int? totalCount, string? error)> GetAll(UserFilter filter);
    // Task<(List<UserResponse>? data, int? totalCount, string? error)> GetAllByRealty_ProjectId(UserNotifyFilter filter);
    Task<(UserResponse? data, string? error)> Update(int id, UserUpdate update);

    Task<(UserResponse? data, string? error)> DeleteById(int id);
    
    Task<(UserDto?, string? error)> AddPermission(UserPermissionsUpdate update);
    Task<(UserDto?, string? error)> RemovePermission(UserPermissionsUpdate update);

    Task<(UserDto?, string? error)> FollowUser(FollowForm followForm, int userId);
    Task<(List<UserResponse>? data, int? totalCount, string? error)> GetFollowers(FollowFilter filter);

    Task<(List<UserResponse>? data, int? totalCount, string? error)> GetFollowing(FollowFilter filter);


}