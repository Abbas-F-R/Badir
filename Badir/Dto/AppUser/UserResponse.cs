namespace Badir.Dto.AppUser;

public class UserResponse
{
    public int Id { get; set; }
    public  string? Name { get; set; }
    public  string? Username { get; set;}
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    public string? Image { get; set; }
    public string? Role { get; set; }
}