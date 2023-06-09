using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.Views.ViewModel
{
    public class UserRoleVM
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Role { get; set; }
        public int Status { get; set; }
        public List<Role> Roles { get; set; }
    }
}
