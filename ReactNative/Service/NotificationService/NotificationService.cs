using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;

namespace ReactNative.Service.NotificationService;

public class NotificationService(
    IRepositoryWrapper wrapper,
    IMapper mapper,
    FirebaseMessaging firebaseMessaging) : INotificationService
{
    public async Task<(NotificationDto? data, string? error)> Add(NotificationForm form)
    {
        var topic = await wrapper.Topic.Get(t => t.Name == form.TopicName,
            x => x.Include(u => u.Users!));

        if (topic == null)
        {
            return (null, "Topic not found");
        }

        var message = new Message()
        {
            Topic = topic.Name,
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Title = form.Title,
                Body = form.Content,
                ImageUrl = form.ImageUrl,
            },
            Data = new Dictionary<string, string>()
            {
                { "url", form.Url }
            },
        };
        var notificationResult = await firebaseMessaging.SendAsync(message);
        if (notificationResult == null)
        {
            return (null, "لم يتم ارسال الاشعار");
        }

        var notification = mapper.Map<Model.Notification>(form);
        notification.Users = topic.Users;
        var result = await wrapper.Notification.Add(notification);
        return result != null ? (mapper.Map<NotificationDto>(result), null) : (null, "لم يتم اضافة الاشعار");
    }


    // public async Task<(NotificationDto? data, string? error)> NotifyMany(NotificationForm form)
    // {
    //     var topic = await wrapper.Topic.Get(t => t.Name == form.TopicName,
    //         x => x.Include(u => u.Users!));
    //
    //     if (topic == null)
    //     {
    //         return (null, "Topic not found");
    //     }
    //
    //     var message = new Message()
    //     {
    //         Topic = topic.Name,
    //         Notification = new FirebaseAdmin.Messaging.Notification
    //         {
    //             Title = form.Title,
    //             Body = form.Content,
    //             ImageUrl = form.ImageUrl,
    //         },
    //         Data = new Dictionary<string, string>()
    //         {
    //             { "url", form.Url }
    //         },
    //     };
    //     var notificationResult = await firebaseMessaging.SendAsync(message);
    //     if (notificationResult == null)
    //     {
    //         return (null, "لم يتم ارسال الاشعار");
    //     }
    //
    //     var notification = mapper.Map<Model.Notification>(form);
    //     notification.Users = topic.Users;
    //     var result = await wrapper.Notification.Add(notification);
    //     return result != null ? (mapper.Map<NotificationDto>(result), null) : (null, "لم يتم اضافة الاشعار");
    // }

    
    
    
    public async Task<(List<NotificationResponse>? data, int? totalCount, string? error)> GetAll(
        NotificationFilter filter)
    {
        var (date, totalCount) = await wrapper.Notification.GetAll(
            n => (!filter.UserId.HasValue || (n.Users!.Any(u => filter.UserId!.Value == u.Id)))
                 // && (!filter.TopicId.HasValue || (n.TopicId == filter.TopicId.Value))
                 // || (!filter.UserId.HasValue || (n.Topic!.UserId == filter.UserId.Value)),
                 ,
            x => x.Include(n => n.UserNotifications!.Where(un => un.UserId == filter.UserId)),
            filter.PageNumber,
            filter.PageSize);
        return (date != null && totalCount > 0)
            ? (mapper.Map<List<NotificationResponse>>(date), totalCount, null)
            : (null, null, " not found");
    }
}