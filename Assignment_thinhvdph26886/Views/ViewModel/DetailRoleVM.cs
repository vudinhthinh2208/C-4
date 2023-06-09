using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.Views.ViewModel
{
    public class DetailRoleVM
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public int Status { get; set; }
    }
}

