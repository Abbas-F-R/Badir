namespace Badir.Dto.Notification;

public class NotificationResponse
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public string? Url { get; set; }
    public string? Date { get; set; }
    public bool? IsRead { get; set; }
}