using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sdt { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual List<Product> Product { get; set; }
    }
}
