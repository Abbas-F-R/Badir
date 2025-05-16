namespace Badir.Service.LikeService;

public interface ILikeService
{ 
    Task<(LikeDto? data, string? error)> LikeUnlikePost(LikeForm form, int userId);

}