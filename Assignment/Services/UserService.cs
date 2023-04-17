using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class UserService : IUserService
    {
        AssDbContext context = new AssDbContext();
        public bool CreateUser(User u)
        {

            try
            {
                context.Users.Add(u);
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
                var user = context.Users.Find(id);
                context.Users.Remove(user); 
                context.SaveChanges();
                return true;
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
            return context.Users.FirstOrDefault();
        }

        public List<User> GetUsersByName(string name)
        {
            return context.Users.Where(p=>p.Username.Contains(name)).ToList();
        }

        public bool UpdateUser(User u)
        {
            try
            {
                var user = context.Users.Find(u.ID);
                user.Password=u.Password;
                user.Status=u.Status;
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
