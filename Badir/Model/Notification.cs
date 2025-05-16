using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model;

[Table("notifications")]

public class Notification : BaseEntity
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public string?  Date { get; set; } = DateTime.UtcNow.ToString();

    public int? TopicId { get; set; }
    // public Topic? Topic { get; set; }
    public ICollection<User>? Users { get; set; } = new List<User>();
    public ICollection<UserNotification>? UserNotifications { get; set; }
}