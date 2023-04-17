using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class RoleService : IRoleService
    {
        AssDbContext context = new AssDbContext();
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
                var role = context.Roles.Find(id);
                context.Roles.Remove(role);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Role> GetAllRole()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.FirstOrDefault(p => p.ID == id);
        } 
        public List<Role> GetRoleByName(string name)
        {
            return context.Roles.Where(p=>p.RoleName.Contains(name)).ToList();
        }

        public bool UpdateRole(Role r)
        {
            try
            {
                var role = context.Roles.Find(r.ID);
                role.RoleName = r.RoleName;
                role.Description= r.Description;
                role.Status = r.Status;
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
