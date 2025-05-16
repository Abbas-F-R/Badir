using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.Post;

public class PostForm
{
    [Required(ErrorMessage = "User Id is required")]
    public required int UserId { get; set; }

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Content is required.")]
    [StringLength(500, ErrorMessage = "Content cannot be longer than 500 characters.")]
    public required string Content { get; set; }

    public string? Image { get; set; }

    public required string Date { get; set; } 

    public required string Time { get; set; } 
    public required string Location { get; set; } 
    public required int PersonsNumber { get; set; } 

    
    public required List<int> TagIds { get; set; }
}