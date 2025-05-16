namespace ReactNative.Service;

public class ReplayCommentLikeService(IRepositoryWrapper wrapper, IMapper mapper) : IReplayCommentLikeService
{
    public async Task<(LikeDto? data, string? error)> LikeUnlikeReplayComment(ReplayCommentLikeForm form, int userId)
    {
        var replayComment = await wrapper.ReplayComment.GetById(form.ReplayCommentId!.Value);
        if (replayComment == null)
        {
            return (null, "رد التعليق غير موجود");
        }

        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, "المستخدم غير موجود");
        }

        var like = await wrapper.ReplayLike.Get(l => l.ReplayCommentId == form.ReplayCommentId && l.UserId == userId);
        if (like == null)
        {
            var result = new ReplayCommentLike
            {
                ReplayCommentId = form.ReplayCommentId,
                UserId = userId
            };
            var likeCreated = await wrapper.ReplayLike.Add(result);
            return likeCreated != null ? (new LikeDto { IsLiked = true }, null) : (null, "لم يتم إضافة الإعجاب");
        }
        else
        {
            var likeDeleted = await wrapper.ReplayLike.Delete(like.Id);
            return likeDeleted != null ? (new LikeDto { IsLiked = false}, null) : (null, "لم يتم حذف الإعجاب");
        }
    }

}