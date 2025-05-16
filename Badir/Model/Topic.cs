using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model;

[Table("topics")]
public class Topic : BaseEntity
{
    public string? Name { get; set; }
    public int? UserId { get; set; }
    public ICollection<Notification>? Notifications { get; set; } = new List<Notification>();
    public ICollection<User>? Users { get; set; } = new List<User>();
}