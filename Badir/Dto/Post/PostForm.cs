using System.ComponentModel.DataAnnotations;

namespace Badir.Dto.Post;

public class PostForm
{
   
    public required int UserId { get; set; }

    
    public required string Title { get; set; }

   
    public required string Content { get; set; }

    public string? Image { get; set; }

    public required string Date { get; set; } 

    public required string Time { get; set; } 
    public required string Location { get; set; } 
    public required int PersonsNumber { get; set; } 

    
    public required List<int> TagIds { get; set; }
}