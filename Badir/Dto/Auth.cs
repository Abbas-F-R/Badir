namespace Badir.Dto;

public class Auth
{
    public  int Id { get; set; }
    public string? Username { get; set; } 
    public string? Token { get; set; }
    public Auth(string username, string token, int id)
    {
        Username = username;
        Token = token;
        Id = id;
    }
}