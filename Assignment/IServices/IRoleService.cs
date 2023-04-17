﻿using Assignment.Models;

namespace Assignment.IServices
{
    public interface IRoleService
    {
        public bool CreateRole(Role r);
        public bool UpdateRole(Role r);
        public bool DeleteRole(Guid id);

        public List<Role> GetAllRole();
        public Role GetRoleById(Guid id);
        public List<Role> GetRoleByName(string name);
    }
}
