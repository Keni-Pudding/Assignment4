using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Role
    {
        [Key]
        public Guid ID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual List<User> Users { get; set; }

    }
}
