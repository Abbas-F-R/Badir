
using System.ComponentModel.DataAnnotations.Schema;

namespace Badir.Model
{
    [Table("users")]

    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? PasswordHash { get; set; }
        public string? Username { get; set; }
        public Role? Role { get; set; }
        public string? Phone1 { get; set; } = "";
        public string? Phone2 { get; set; } = "";
        public string? Image { get; set; } = "";
        
        public int? followers { get; set; } = 0;
        public int? following { get; set; } = 0; 

        
        public ICollection<Rate> Rates { get; set; } = new List<Rate>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public bool UpdateTopics { get; set; } = true;
        public ICollection<Topic>? Topics { get; set; } = new List<Topic>();
        public ICollection<Notification>? Notifications { get; set; } = new List<Notification>(); 
        public ICollection<UserNotification>? UserNotifications { get; set; } = new List<UserNotification>();
        public ICollection<Permission>? Permission { get; set; } = new List<Permission>(); 
        public ICollection<CampaignInvitation> CampaignInvitations { get; set; }  

        // public ICollection<Follow>? Follows { get; set; } = new List<Follow>(); 

       



        public User(string? name, string? passwordHash, string username, Role role, string phone1, string phone2,
            string image)
        {
            Name = name;
            PasswordHash = passwordHash;
            Username = username;
            Role = role;
            Phone1 = phone1;
            Phone2 = phone2;
            Image = image;
        }

        public User()
        {
        }
        
        
        public override string ToString()
        {
            return $"Name: {Name}, Username: {Username}, Role: {Role}";
        }
    }



}
