namespace Badir.Interface;

public interface IRepositoryWrapper
{
    IUserRepository User { get; }
    IPostRepository Post { get; }
    ILikeRepository Like { get; }
    IRateRepository Rate { get; }
    INotificationRepository Notification { get; }
    IUserNotificationRepository UserNotification { get; }
    IHashtagRepository Hashtag { get; }
    IPermissionRepository Permission { get; }
    ITopicRepository Topic { get; }
    IReplayCommentRepository ReplayComment { get; }
    ICommentRepository Comment { get; }
    IReplayLikeRepository ReplayLike { get; }
    ICommentLikeRepository CommentLike { get; }
    IFollowRepository Follow { get; }
    ICampaignActivitiesRepository CampaignActivity { get; }
    ICampaignInvitationRepository CampaignInvitation { get; }
}