namespace Assignment_thinhvdph26886.Models
{
    public class User
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid Role { get; set; }
        public int Status { get; set; }
        public virtual Role Roles { get; set; }
        public virtual List<Bill> Bills { get; set; }
        public virtual Cart Carts { get; set; }
    }
}
