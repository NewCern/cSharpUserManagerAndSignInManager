using Microsoft.AspNetCore.Identity;

namespace UserManagerAndSignInManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Extended Attributes HERE
        public string city { get; set; }
    }
}
