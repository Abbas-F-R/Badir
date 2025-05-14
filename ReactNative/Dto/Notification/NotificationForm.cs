using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.Notification
{
    public class NotificationForm
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public required string Title { get; set; }  

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(500, ErrorMessage = "Content cannot be longer than 500 characters.")]
        public required string Content { get; set; }

        [Required(ErrorMessage = "ImageUrl is required.")]
        [Url(ErrorMessage = "Invalid URL format for ImageUrl.")]
        public required string ImageUrl { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public required string? Url { get; set; } = "";

        [Required(ErrorMessage = "Topic Name is required.")]
        public required string TopicName { get; set; }
    }
}