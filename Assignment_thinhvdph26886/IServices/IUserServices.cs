using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.IServices
{
    public interface IUserServices
    {
        public bool CreateUser(User i);
        public bool UpdateUser(User i);
        public bool DeleteUser(Guid id);
        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUserByName(string name);
    }
}
