
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Badir.Service;
using Badir.Service.CommentService;


namespace Badir.Extensions;

public static class ApplicationServicesExtension
{
  
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    
    {
  
       var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("##########################    CONNECTION_STRING is not set in the environment variables.   ##########################" );
        } 
     

        services.AddDbContext<DatabaseContext>(options =>
            options.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 26))));

        FirebaseApp.Create(new AppOptions()
        {
            Credential =
                GoogleCredential.FromFile(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "firebase-admin-sdk.json")),
        });

        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<ILikeService, LikeService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<ITopicService, TopicService>();
        services.AddScoped<IUserNotificationService, UserNotificationService>();
        services.AddScoped<IHashtagService, HashtagService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ICampaignInvitationService, CampaignInvitationService>();
        services.AddScoped<ICampaignActivitiesService, CampaignActivitiesService>();
        
        
        services.AddScoped<ICommentLikeService, CommentLikeService>();
        services.AddScoped<IReplayCommentLikeService, ReplayCommentLikeService>();
        services.AddScoped<IRateService, RateService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<FirebaseMessaging>(_ => FirebaseMessaging.DefaultInstance);
        services.AddHttpContextAccessor();
        services.AddScoped<ClaimsUtils>();
        services.AddHostedService<SeedDataService>();
        services.AddScoped<TokenService>();
        return services;
    }
}