using Microsoft.EntityFrameworkCore;

namespace ReactNative.Service.UserService;

public class UserService(
    IRepositoryWrapper wrapper,
    IMapper mapper,
    IFileService file
) : IUserService
{
    public async Task<(UserDto? data, string? error)> Get(int id)
    {
        var user = await wrapper.User.Get(u => u.Id == id,
            x => x.Include(u => u.Topics!).Include(u => u.Permission!)
              );
        return user != null
            ? (mapper.Map<UserDto>(user), null)
            : (null, " المستخدم غير موجود");
    }

   
    public async Task<(List<UserResponse>? data, int? totalCount, string? error)> GetAll(UserFilter filter)
    {
        var (data, totalCount) = await wrapper.User.GetAll(
            u => (string.IsNullOrEmpty(filter.Name) || u.Name!.ToLower().Contains(filter.Name.ToLower())) &&
                 (filter.Role == null || u.Role == filter.Role),
            filter.PageNumber,
            filter.PageSize);
        return (data != null && totalCount != 0)
            ? (mapper.Map<List<UserResponse>>(data), totalCount, null)
            : (null, null, "لم يتم جلب المستخدمين");
    }


    public async Task<(UserResponse? data, string? error)> Update(int id, UserUpdate update)
    {
        var user = await wrapper.User.Get(u => u.Id == id,
                x => x.Include(u => u.Topics!).Include(u => u.Permission!));
        if (user == null)
        {
            return (null, "المستخدم غير موجود");
        }

        var (imageData, imageError) = await file.UpdateImageAsync(user.Image, update.Image);
        if (imageError != null)
        {
            return (null, imageError);
        }

        mapper.Map(update, user);
        user.Image = imageData;
        var result = await wrapper.User.Update(user);

        return result != null
            ? (mapper.Map<User, UserResponse>(user), null)
            : (null, "لم يتم تحديث المستخدم");
    }


    public async Task<(UserResponse? data, string? error)> DeleteById(int id)
    {
        var user = await wrapper.User.GetById(id);
        if (user == null)
        {
            return (null, "المستخدم غير موجود");
        }
        

        var error = await DeleteUserTopicAsync(user.Username!);
        if (error != null)
        {
            Console.WriteLine($"Error: {error}");
        }

        user.Username = user.Username + "_" + user.Id + "_" + DateTime.Now.ToString("yyyyMMddHHmmss");
        var updated = await wrapper.User.Update(user);
        if (updated == null)
        {
            return (null, "لم يتم تحديث المستخدم" );
        }

        var delete = await wrapper.User.SoftDelete(id);
        return delete == null
            ? (null, "المستخدم غير موجود ")
            : (mapper.Map<UserResponse>(delete), null);
    }


    public async Task<(UserDto?, string? error)> FollowUser(FollowForm followForm, int userId)
    {
         var follower = await wrapper.User.GetById(userId);
         if (follower == null)
         {
             return (null, " لم يتم ايجاد المستخدم");
         }
         var following = await wrapper.User.GetById(followForm.followerId);
         if (following == null)
         {
             return (null, " لم يتم ايجاد المستخدم");
         }

         var follow = new Follow()
         {
             FollowerId = follower.Id,
             FollowingId = following.Id,
         };
         var existFollow = await wrapper.Follow.Get(f => f.following!.Id == followForm.followerId && f.follower!.Id == userId);
         if (existFollow != null)
         {
             await wrapper.Follow.Delete(existFollow.Id);
             follower.following--;
             following.followers--;
             await wrapper.User.Update(follower);
             await wrapper.User.Update(following);
             return (mapper.Map<UserDto>(follower), null);
         }
         follower.following++;
         following.followers++;
         await wrapper.User.Update(follower);
         await wrapper.User.Update(following);
         var result = await wrapper.Follow.Add(follow);
         return result != null ? (mapper.Map<UserDto>(follower), null) : (null, "   ");
    }

    public async Task<(List<UserResponse>? data, int? totalCount, string? error)> GetFollowers(FollowFilter filter)
    {
        var (data, totalCount) = await wrapper.Follow.GetAll(
            f => ( f.follower!.Id == filter.UserId),
            x => x.Include(f => f.follower!),
            filter.PageNumber,
            filter.PageSize);
        return (data != null && totalCount != 0)
            ? (mapper.Map<List<UserResponse>>(data.Select(f => f.follower).ToList()), totalCount, null)
            : (null, null, "لم يتم جلب المستخدمين");
    }

    public async Task<(List<UserResponse>? data, int? totalCount, string? error)> GetFollowing(FollowFilter filter)
    {
        var (data, totalCount) = await wrapper.Follow.GetAll(
            f => ( f.following!.Id == filter.UserId),
            x => x.Include(f => f.following!),
            filter.PageNumber,
            filter.PageSize);
        return (data != null && totalCount != 0)
            ? (mapper.Map<List<UserResponse>>(data.Select(f => f.following).ToList()), totalCount, null)
            : (null, null, "لم يتم جلب المستخدمين");
    }


    private async Task<string?> DeleteUserTopicAsync(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            return "Username cannot be empty.";
    
        var topic = await wrapper.Topic.Get(t => t.Name == username);
    
        if (topic == null)
            return "Topic not found.";
    
        await wrapper.Topic.SoftDelete(topic.Id);
    
        return null; // No errors
    }
}