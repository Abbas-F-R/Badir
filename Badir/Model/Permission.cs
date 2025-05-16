using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model;

[Table("permissions")]
public class Permission : BaseEntity
{
    public required string ArabicName { get; set; }
    public required PermissionType? PermissionType { get; set; }
    public  List<User> Users { get; set; } = new List<User>();
    public required EntityType EntityType;
    public required PermissionsCategories PermissionsCategories { get; set; }
    
    
}