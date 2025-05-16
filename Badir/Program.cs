global using ReactNative.Model;
global using ReactNative.Repository;
global using ReactNative.Interface;
global using ReactNative.Enums;
global using ReactNative.Base;
global using ReactNative.Dto;
global using ReactNative.Dto.Like;
global using ReactNative.Dto.Post;
global using ReactNative.Dto.AppUser;
global using ReactNative.Dto.Like;
global using ReactNative.Dto.Rate;
global using ReactNative.Dto.File;
global using ReactNative.Dto.ReplayComment;
global using ReactNative.Dto.Comment;
global using ReactNative.Dto.Notification;
global using ReactNative.Dto.UserNotification;
global using ReactNative.Dto.Permission;
global using ReactNative.Dto.Hashtag;
global using ReactNative.Dto.Topic;
global using ReactNative.Dto.ReplayCommentLike;
global using ReactNative.Dto.CommentLike;
global using ReactNative.Dto.Follow;
global using ReactNative.Dto.CampaignInvitation;
global using ReactNative.Dto.CampaignActivities;



global using ReactNative.Data;
global using ReactNative.Service.PermissionService;
global using ReactNative.Service.AuthService;
global using ReactNative.Service.CampaignActivitiesService;
global using ReactNative.Service.CampaignInvitationService;

global using ReactNative.Service.CommentLikeService;
global using ReactNative.Service.ReplayCommentService;
global using ReactNative.Service.TopicService;
global using ReactNative.Service.UserService;
global using ReactNative.Service.FileService;
global using ReactNative.Service.CommentService;
global using ReactNative.Service.PostService;
global using ReactNative.Service.RateService;
global using ReactNative.Service.LikeService;
global using ReactNative.Service.TokenService;
global using ReactNative.Service.HashtagService;
global using ReactNative.Service.NotificationService;
global using ReactNative.Service.UserNotificationService;
global using ReactNative.Helper;
global using ReactNative.Helper;
global using AutoMapper;
using DotNetEnv;
using ReactNative.Extensions;


var builder = WebApplication.CreateBuilder(args);
Env.Load();

// builder.WebHost.ConfigureKestrel(serverOptions =>
// {
//     serverOptions.Listen(IPAddress.Any, 5000); // HTTP
// });
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSecurityExtension(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration); 



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("http://192.168.42.63:8081","http://192.168.42.63:8081","https://frontend.alrwabi.com", "http://localhost:3000", "http://192.168.77.191:3000", "http://localhost:8081")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
    });
});



var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();