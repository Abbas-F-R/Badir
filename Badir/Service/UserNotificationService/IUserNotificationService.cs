namespace Badir.Service.UserNotificationService;

public interface IUserNotificationService
{
    Task<(UserNotificationDto? date, string? error)> Add(UserNotificationForm form, int userId);
}