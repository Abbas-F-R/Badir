namespace Badir.Dto.Post;

public class PostResponse
{
    public int? Id { get; set; }
    public int? ProjectId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }
    public string? LikeCount { get; set; }
    public string? Click_Count { get; set; }
    public string? Viwe_Count { get; set; }
    public string? UserProfileImage { get; set; }
    public string? UserName { get; set; }
    public string? Date { get; set; } 

    public string? Time { get; set; } 
    public string? Location { get; set; } 
    public int? PersonsNumber { get; set; } 
    public string? RequiredVolunteers { get; set; } 


    public bool? IsLike { get; set; }
    public List<HashtagResponse> Hashtags { get; set; }
    public int JoinedCount { get; set; }


}