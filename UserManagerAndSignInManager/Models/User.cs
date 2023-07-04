using System.ComponentModel.DataAnnotations;

namespace UserManagerAndSignInManager.Models
{
    // PLACEHOLDER USER JUST FOR THE PURPOSE OF TESTING
    public partial class User 
    {
        //Key May or May not be needed
        //[Key]
        public int Id { get; set; } 
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType("Password")]
        public string Password { get; set; }
    }
}
