using Badir.Dto.Notification;

namespace Badir.Service.NotificationService;

public interface INotificationService
{
    Task<(NotificationDto? data, string? error)> Add(NotificationForm form);
    Task<(List<NotificationResponse>? data, int? totalCount, string? error)> GetAll(NotificationFilter filter);
}