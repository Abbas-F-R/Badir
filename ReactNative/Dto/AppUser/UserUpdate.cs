using System.ComponentModel.DataAnnotations;

namespace ReactNative.Dto.AppUser;

public class UserUpdate
{
    public string? Name { get; set; }
    public string? Phone1 { get; set; }
    public string? Phone2 { get; set; }
    // public bool? UpdateTopics { get; set; }
    public string? Image { get; set; }
}