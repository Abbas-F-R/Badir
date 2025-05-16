
namespace ReactNative.Repository;

public class RepositoryWrapper(DatabaseContext context, IMapper mapper) : IRepositoryWrapper
{

  
    private IUserRepository? _user;
    private IPostRepository? _post;
    private ILikeRepository? _like;
    private IRateRepository? _rate;
    private INotificationRepository? _notification;
    private IUserNotificationRepository? _userNotification;
    private IHashtagRepository? _Hashtag;
    private IPermissionRepository? _permission;
    private ITopicRepository? _topic;
    private ICommentRepository? _comment;
    private IReplayCommentRepository? _replayComment;
    private IReplayLikeRepository? _replayLike;
    private ICommentLikeRepository? _commentLike;
    private IFollowRepository? _follow;
    private ICampaignActivitiesRepository? _campaignActivities;
    private ICampaignInvitationRepository? _campaignInvitation;
    
    
  

    
    
    
    
    
    public IUserRepository User => _user ??= new UserRepository(context, mapper);
   
    public IPostRepository Post => _post??= new PostRepository(context, mapper);
    public ILikeRepository Like => _like ??= new LikeRepository(context, mapper);
    public IRateRepository Rate => _rate ??= new RateRepository(context, mapper);
    public INotificationRepository Notification => _notification ??= new NotificationRepository(context, mapper);
    public IUserNotificationRepository UserNotification => _userNotification ??= new UserNotificationRepository(context, mapper); 
    public IHashtagRepository Hashtag => _Hashtag ??= new HashtagRepository(context, mapper);
    public IPermissionRepository Permission => _permission ??= new PermissionRepository(context, mapper);
    public ITopicRepository Topic => _topic ??= new TopicRepository(context, mapper);
    public ICommentRepository Comment => _comment ??= new CommentRepository(context, mapper);
    public IReplayCommentRepository ReplayComment => _replayComment ??= new ReplayCommentRepository(context, mapper);
    public IReplayLikeRepository ReplayLike => _replayLike ??= new ReplayLikeRepository(context, mapper);
    public ICommentLikeRepository CommentLike => _commentLike ??= new CommentLikeRepository(context, mapper);
    public IFollowRepository Follow => _follow ??= new FollowRepository(context, mapper);
    public ICampaignActivitiesRepository CampaignActivity => _campaignActivities ??= new CampaignActivitiesRepository(context, mapper);
    public ICampaignInvitationRepository CampaignInvitation => _campaignInvitation ??= new CampaignInvitationRepository(context, mapper);
}