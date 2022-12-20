using System.ComponentModel.DataAnnotations;

namespace BasicCore.Models
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
