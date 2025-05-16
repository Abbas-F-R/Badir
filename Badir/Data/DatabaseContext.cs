using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Badir.Data;

public class DatabaseContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public DatabaseContext(
        DbContextOptions<DatabaseContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Rate> Rates { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserNotification> UserNotifications { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<CommentLike> CommentLikes { get; set; }
    public DbSet<ReplayCommentLike> ReplayCommentLikes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ReplayComment> ReplayComments { get; set; }
    public DbSet<Follow> Follows { get; set; }
    public DbSet<CampaignInvitation> CampaignInvitations { get; set; }
    public DbSet<CampaignActivities> CampaignActivities { get; set; }

}