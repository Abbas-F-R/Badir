using System.ComponentModel.DataAnnotations;

namespace Badir.Dto.AppUser
{
    public class UserForm
    {
        public required string Name { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}