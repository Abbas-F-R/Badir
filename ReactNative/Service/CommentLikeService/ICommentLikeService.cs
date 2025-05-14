namespace ReactNative.Service.CommentLikeService;

public interface ICommentLikeService
{
    Task<(LikeDto? data, string? error)> LikeUnlikeComment(CommentLikeForm form, int userId);

}