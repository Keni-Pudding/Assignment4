using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class User
    {
        [Key]
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleID { get; set; }
        public int Status { get; set; }

        public virtual List<Bill> Bills { get; set; }

        public virtual Role Role { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
