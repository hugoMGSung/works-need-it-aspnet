using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace BasicBoard.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordCheck { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public string Gender { get; set; } 
        public string Address { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
