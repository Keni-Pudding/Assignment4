using Assignment.Models;
namespace Assignment.IServices
{
    public interface IUserService
    {
        public bool CreateUser(User u);
        public bool UpdateUser(User u);
        public bool DeleteUser(Guid id);

        public List<User> GetAllUsers();
        public User GetUserById(Guid id);
        public List<User> GetUsersByName(string name);
    }
}
