
namespace ReactNative.Dto.AppUser;

public class UserDto
{
    public int Id { get; set; }
    public  string? Name { get; set; }
    public  string? Username { get; set;}
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? Image { get; set; }
    public int? followers { get; set; } 
    public int? following { get; set; } 
    public bool UpdateTopics { get; set; }
    public List<PermissionResponse> Permission { get; set; } = [];
}