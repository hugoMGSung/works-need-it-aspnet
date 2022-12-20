using Microsoft.AspNetCore.Identity;

namespace BasicCore.Models
{
    public class CustomUser : IdentityUser
    {
        public string City { get; set; }
    }
}
