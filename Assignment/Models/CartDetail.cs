using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class CartDetail
    {
        [Key]
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
