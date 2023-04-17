using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Cart
    {
        [Key]
        public Guid UserID { get; set; }
        public string Description { get; set; }
        public virtual User Users { get; set; }
        public virtual List<CartDetail> CartDetails { get; set; }

        
    }
}
