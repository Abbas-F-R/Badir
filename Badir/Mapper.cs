
namespace ReactNative
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            // User Maps
            CreateMap<User, UserDto>();
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.Role,
                    opt => opt.MapFrom((src) =>
                        src.Role));
            CreateMap<UserUpdate, User>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom((src, dest) =>
                        !string.IsNullOrEmpty(src.Name) ? src.Name : dest.Name))
                .ForMember(dest => dest.Phone1,
                    opt => opt.MapFrom((src, dest) =>
                        !string.IsNullOrEmpty(src.Phone1) ? src.Phone1.Trim() : dest.Phone1!.Trim()))
                .ForMember(dest => dest.Phone2,
                    opt => opt.MapFrom((src, dest) =>
                        !string.IsNullOrEmpty(src.Phone2) ? src.Phone2.Trim() :
                        !string.IsNullOrEmpty(dest.Phone2) ? dest.Phone2.Trim() : ""))
                // .ForMember(dest => dest.UpdateTopics,
                //     opt => opt.MapFrom((src, dest) => src.UpdateTopics ?? dest.UpdateTopics))
                .ForMember(dest => dest.Image,
                    opt => opt.Ignore());

        
            // House Maps
            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.UserProfileImage, opt =>
                    opt.MapFrom(src => src.User != null ? src. User.Image : string.Empty))
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.User != null ? src.User.Username : string.Empty))
                .ForMember(dest => dest.JoinedCount, opt =>
                    opt.MapFrom(src => src.CampaignInvitation!.Users!.Count() ))
                .ForMember(dest => dest.RequiredVolunteers, opt =>
                    opt.MapFrom(src => src.PersonsNumber - src.CampaignInvitation!.Users!.Count()  ))
                .ForMember(dest => dest.IsLike, opt =>
                    opt.MapFrom(src => src.Likes!.Any() ? true : false));
            CreateMap<PostForm, Post>();


            CreateMap<PostUpdate, Post>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom((src, dest) =>
                    string.IsNullOrEmpty(src.Title) ? dest.Title : src.Title))
                .ForMember(dest => dest.Time, opt => opt.MapFrom((src, dest) =>
                    string.IsNullOrEmpty(src.Time) ? dest.Time : src.Time))
                .ForMember(dest => dest.Location, opt => opt.MapFrom((src, dest) =>
                    string.IsNullOrEmpty(src.Location) ? dest.Location : src.Location))
                .ForMember(dest => dest.Image,
                    opt => opt.Ignore());
            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.UserProfileImage, opt =>
                    opt.MapFrom(src => src.User != null ? src. User.Image : string.Empty))
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.User != null ? src.User.Username : string.Empty))
                .ForMember(dest => dest.JoinedCount, opt =>
                    opt.MapFrom(src => src.CampaignInvitation!.Users!.Count() ))
                .ForMember(dest => dest.RequiredVolunteers, opt =>
                    opt.MapFrom(src => src.PersonsNumber - src.CampaignInvitation!.Users!.Count()  ))
                .ForMember(dest => dest.IsLike, opt =>
                    opt.MapFrom(src => src.Likes!.Any() ? true : false));

            // Notification Map
            CreateMap<Notification, NotificationDto>();
            CreateMap<NotificationForm, Notification>()
                .ForMember(dest => dest.ImageUrl, otp =>
                    otp.MapFrom((src, dest) => new Uri(src.ImageUrl).AbsolutePath.TrimStart('/').ToString()));
            CreateMap<Notification, NotificationResponse>()
                .ForMember(dest => dest.IsRead,
                    opt => opt.MapFrom(src => src.UserNotifications != null && src.UserNotifications.Any()
                        ? src.UserNotifications.First().IsRead
                        : false));

            // Rate Maps
            CreateMap<Rate, RateDto>();
            CreateMap<RateForm, Rate>();
            CreateMap<RateUpdate, Rate>();


            // Like Maps
            CreateMap<LikeForm, Like>();
            CreateMap<bool, LikeDto>()
                .ForMember(dest => dest.IsLiked, opt =>
                    opt.MapFrom((src) => src));


           

            // UserNotification Map
            CreateMap<UserNotification, UserNotificationDto>();
            CreateMap<UserNotificationForm, UserNotification>();


           


          
         

            // Hashtag map 
            CreateMap<Hashtag, HashtagDto>();
            CreateMap<HashtagForm, Hashtag>();
            CreateMap<HashtagUpdate, Hashtag>()
                .ForMember(dest => dest.Name, otp =>
                    otp.MapFrom((src, dest) => !string.IsNullOrEmpty(src.Name) ? src.Name : dest.Name));
            CreateMap<Hashtag, HashtagResponse>();



            // Permission Map
            CreateMap<Permission, PermissionResponse>();
            CreateMap<Permission, PermissionResponseSystem>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                    src.PermissionType.HasValue
                        ? PermissionTypeExtensions.GetPermissionName(src.PermissionType.Value)
                        : ""
                ));


            
            // Mapping between Comment and CommentDto
            CreateMap<Comment, CommentDto>()
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.User != null ? src.User.Username : ""));

// Mapping between CommentForm and Comment
            CreateMap<CommentForm, Comment>()
                .ForMember(dest => dest.Content, opt =>
                    opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.UserId, opt =>
                    opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.PostId, opt =>
                    opt.MapFrom(src => src.PostId));

// Mapping between CommentUpdate and Comment
            CreateMap<CommentUpdate, Comment>()
                .ForMember(dest => dest.Content, opt => opt.MapFrom((src, dest) =>
                    string.IsNullOrEmpty(src.Content) ? dest.Content : src.Content));

// Mapping between Comment and CommentResponse
            CreateMap<Comment, CommentResponse>()
                .ForMember(dest => dest.UserName, opt =>
                    opt.MapFrom(src => src.User != null ? src.User.Username : ""));

        

        }
    }
}