using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.Post;

public class PostUpdate
{
    public string? Title { get; set; }

    public string? Content { get; set; }

    public string? Image { get; set; }
    public string? Date { get; set; } 

    public string? Time { get; set; } 
    public string? Location { get; set; } 
    public int? PersonsNumber { get; set; } 

}