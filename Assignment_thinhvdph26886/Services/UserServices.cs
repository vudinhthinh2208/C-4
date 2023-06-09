using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_thinhvdph26886.Services
{
    public class UserServices : IUserServices
    {
        ShoppingDbContext context;
        public UserServices()
        {
            context = new ShoppingDbContext();
        }

        public bool CreateUser(User i)
        {
            try
            {
                context.Users.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var bill = context.Users.FirstOrDefault(p => p.UserID == id);
                if (bill != null)
                {
                    context.Users.Remove(bill);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.FirstOrDefault(c => c.UserID == id);
        }
        public List<User> GetUserByName(string name)
        {
            return context.Users.Where(p => p.Username == name).ToList();
        }


        public bool UpdateUser(User i)
        {
            try
            {
                var x = context.Users.FirstOrDefault(p => p.UserID == i.UserID);
                x.Username = i.Username;
                x.Password = i.Password;
                x.Roles = i.Roles;
                x.Status = i.Status;
                context.Users.Update(x);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
