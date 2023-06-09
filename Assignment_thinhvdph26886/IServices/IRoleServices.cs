using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.IServices
{
    public interface IRoleServices
    {
        public bool CreateRole(Role i);
        public bool UpdateRole(Role i);
        public bool DeleteRole(Guid id);
        public List<Role> GetAllRoles();
        public Role GetRoleById(Guid id);
    }
}
