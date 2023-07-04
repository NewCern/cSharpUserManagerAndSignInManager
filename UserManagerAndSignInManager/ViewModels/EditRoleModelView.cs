using System.ComponentModel.DataAnnotations;

namespace UserManagerAndSignInManager.ViewModels
{
    public class EditRoleModelView
    {
        public List<string> Users { get; set; }  // List Users That Belong To Role
        public EditRoleModelView()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string RoleName { get; set; }
    }
}
