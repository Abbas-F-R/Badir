using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model;

[Table("hashtags")]
public class Hashtag : BaseEntity
{
    public string? Name { get; set; } = "";
    public int? UserId { get; set; }
    public User? User { get; set; }
    public List<Post> Posts { get; set; } = new List<Post>();
}