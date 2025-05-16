using System.ComponentModel.DataAnnotations.Schema;

namespace ReactNative.Model;

[Table("user_notifications")]

public class UserNotification : BaseEntity
{
    public int? UserId { get; set; }
    public User? User { get; set; } = null!;
    public int? NotificationId { get; set; }
    public Notification? Notification { get; set; } = null!;
    public bool? IsRead { get; set; } = false;
    public DateTime? ReadDate { get; set; } = DateTime.Now;
}