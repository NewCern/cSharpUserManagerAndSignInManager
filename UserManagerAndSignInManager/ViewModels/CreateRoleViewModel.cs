using System.ComponentModel.DataAnnotations;

namespace UserManagerAndSignInManager.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
