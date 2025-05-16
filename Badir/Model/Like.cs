using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model;

[Table("likes")]

public class Like: LikeBase
{
    public int? PostId { get; set; }
    public Post? Posts { get; set; }
    
}