using ReactNative.Dto.UserNotification;

namespace ReactNative.Service.UserNotificationService;

public class UserNotificationService(IRepositoryWrapper wrapper, IMapper mapper) : IUserNotificationService
{
    public async Task<(UserNotificationDto? date, string? error)> Add(UserNotificationForm form, int userId)
    {
        var existUserNotification =
            await wrapper.UserNotification.Get(un => un.UserId == userId && un.NotificationId == form.NotificationId);
        if (existUserNotification != null) return (mapper.Map<UserNotificationDto>(existUserNotification), null);
        var userNotification = new UserNotification
        {
            UserId = userId,
            NotificationId = form.NotificationId,
            IsRead = true
        };
        var result = await wrapper.UserNotification.Add(userNotification);
        return result != null ? (mapper.Map<UserNotificationDto>(result), null) : (null, "UserNotification added");
    }
}