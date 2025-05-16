namespace Badir.Service.LikeService;

public class LikeService(IRepositoryWrapper wrapper, IMapper mapper) : ILikeService
{
    public async Task<(LikeDto? data, string? error)> LikeUnlikePost(LikeForm form, int userId)
    {
        var post = await wrapper.Post.GetById(form.PostId);
        if (post == null)
        {
            return (null, "Post not found");
        }

        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, "User not found");
        }

        var like = await wrapper.Like.Get((l => l.PostId == form.PostId && l.UserId == userId));
        if (like == null)
        {
            var result = new Like
            {
                PostId = form.PostId,
                UserId = userId
            };
            var likeCreated =  await wrapper.Like.Add(result);
            post.LikeCount += 1;
            await wrapper.Post.Update(post);
            return likeCreated != null ?(new LikeDto { IsLiked = true }, null)  : (null, " Like Added");
        } else
        {
           var likeDeleted =  await wrapper.Like.Delete(like.Id);
            post.LikeCount -= 1;
            await wrapper.Post.Update(post);
            
            return likeDeleted != null ? (new LikeDto { IsLiked = false }, null) : (null, " Like Deleted");
        }
    }

   
}