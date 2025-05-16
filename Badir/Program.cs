global using Badir.Model;
global using Badir.Repository;
global using Badir.Interface;
global using Badir.Enums;
global using Badir.Base;
global using Badir.Dto;
global using Badir.Dto.Like;
global using Badir.Dto.Post;
global using Badir.Dto.AppUser;
global using Badir.Dto.Like;
global using Badir.Dto.Rate;
global using Badir.Dto.File;
global using Badir.Dto.ReplayComment;
global using Badir.Dto.Comment;
global using Badir.Dto.Notification;
global using Badir.Dto.UserNotification;
global using Badir.Dto.Permission;
global using Badir.Dto.Hashtag;
global using Badir.Dto.Topic;
global using Badir.Dto.ReplayCommentLike;
global using Badir.Dto.CommentLike;
global using Badir.Dto.Follow;
global using Badir.Dto.CampaignInvitation;
global using Badir.Dto.CampaignActivities;
global using Badir.Dto.Rate;




global using Badir.Data;
global using Badir.Service.PermissionService;
global using Badir.Service.AuthService;
global using Badir.Service.CampaignActivitiesService;
global using Badir.Service.CampaignInvitationService;

global using Badir.Service.CommentLikeService;
global using Badir.Service.ReplayCommentService;
global using Badir.Service.TopicService;
global using Badir.Service.UserService;
global using Badir.Service.FileService;
global using Badir.Service.CommentService;
global using Badir.Service.PostService;
global using Badir.Service.RateService;
global using Badir.Service.LikeService;
global using Badir.Service.TokenService;
global using Badir.Service.HashtagService;
global using Badir.Service.NotificationService;
global using Badir.Service.UserNotificationService;
global using Badir.Helper;
global using Badir.Helper;
global using AutoMapper;
global using FluentValidation;
using DotNetEnv;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Badir.DtoValidator.BaseValidator;
using Badir.Extensions;




var builder = WebApplication.CreateBuilder(args);
Env.Load();

// builder.WebHost.ConfigureKestrel(serverOptions =>
// {
//     serverOptions.Listen(IPAddress.Any, 5000); // HTTP
// });
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
builder.Services.AddFluentValidationAutoValidation(); // ✅ ضروري
builder.Services.AddFluentValidationClientsideAdapters(); // (اختياري)
builder.Services.AddValidatorsFromAssemblyContaining<Program>(); // ✅ تأكد أنه يحتوي على Validator

// // تعطيل الفلتر التلقائي لعدم إعادة الفورم الافتراضي
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


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