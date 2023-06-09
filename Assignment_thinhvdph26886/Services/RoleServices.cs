using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.Services
{
    public class RoleServices : IRoleServices
    {
        ShoppingDbContext context;
        public RoleServices()
        {
            context = new ShoppingDbContext();
        }
        public bool CreateRole(Role r)
        {
            try
            {
                context.Roles.Add(r);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                var role = context.Roles.FirstOrDefault(c => c.RoleID == id);
                context.Roles.Remove(role);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Role> GetAllRoles()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(c => c.RoleID == id);
        }

        public List<Role> GetRoleByName(string name)
        {
            return context.Roles.Where(c => c.RoleName == name).ToList();
        }

        public bool UpdateRole(Role r)
        {
            try
            {
                var role = context.Roles.Find(r.RoleID);
                role.RoleName = r.RoleName;
                role.Description = r.Description;
                role.Status = r.Status;
                context.Roles.Update(role);
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
