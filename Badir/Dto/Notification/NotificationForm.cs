using System.ComponentModel.DataAnnotations;

namespace Badir.Dto.Notification
{
    public class NotificationForm
    {
       
        public required string Title { get; set; }  
        public required string Content { get; set; }
        public required string ImageUrl { get; set; }
        public required string? Url { get; set; } = "";
        public required string TopicName { get; set; }
    }
}