using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model;

[Table("posts")]

public class Post :BaseEntity
{
   public string? Title { get; set; }
   public string? Image { get; set; }   
   public string? Content { get; set; }
   public int? LikeCount { get; set; } = 0;
   public string? Click_Count { get; set; } = "0";
   public string? Viwe_Count { get; set; } = "0";
   public ICollection<Like>? Likes { get; set; }  
   public string? Time { get; set; } 
   public int? PersonsNumber { get; set; } 

   public string? Location { get; set; } 

   public int? UserId { get; set; } 
   public User? User { get; set; }
   public ICollection<Hashtag> Hashtags { get; set; } = new HashSet<Hashtag>();
   public CampaignInvitation? CampaignInvitation { get; set; } = new CampaignInvitation();
   public ICollection<CampaignActivities> CampaignActivities { get; set; }   = new List<CampaignActivities>();
}