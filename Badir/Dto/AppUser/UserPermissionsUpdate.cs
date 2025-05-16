namespace Badir.Dto.AppUser;

public class UserPermissionsUpdate
{
    public required int Id { get; set; }
    public required List<int> PermissionIds { get; set; } 
}