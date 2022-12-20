using System.ComponentModel.DataAnnotations;

namespace BasicCore.Models
{
    public class EditUserModel
    {
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string City { get; set; }

        public List<string> Claims { get; set; }

        public IList<string> Roles { get; set; }

        public EditUserModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }
    }
}
