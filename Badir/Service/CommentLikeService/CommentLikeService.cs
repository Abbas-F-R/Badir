
namespace Badir.Service.CommentLikeService;

public class CommentLikeService(IRepositoryWrapper wrapper, IMapper mapper) : ICommentLikeService
{
    public async Task<(LikeDto? data, string? error)> LikeUnlikeComment(CommentLikeForm form, int userId)
    {
        // التحقق من وجود التعليق
        var comment = await wrapper.Comment.GetById(form.CommentId);
        if (comment == null)
            return (null, "لم يتم العثور على التعليق");

        // التحقق من وجود المستخدم
        var user = await wrapper.User.GetById(userId);
        if (user == null)
            return (null, "المستخدم غير موجود");

        // تحقق إذا سبق وأعجب بالتعليق
        var like = await wrapper.CommentLike.Get(c => c.CommentId == form.CommentId && c.UserId == userId);

        if (like == null)
        {
            var newLike = new CommentLike
            {
                CommentId = form.CommentId,
                UserId = userId
            };

            var addedLike = await wrapper.CommentLike.Add(newLike);
            comment.LikeCount += 1;
            await wrapper.Comment.Update(comment);

            return addedLike != null ? (new LikeDto { IsLiked = true }, null) : (null, "حدث خطأ أثناء الإعجاب");
        }
        else
        {
            var deletedLike = await wrapper.CommentLike.Delete(like.Id);
            comment.LikeCount -= 1;
            await wrapper.Comment.Update(comment);

            return deletedLike != null ? (new LikeDto { IsLiked = false }, null) : (null, "حدث خطأ أثناء إزالة الإعجاب");
        }
    }
}