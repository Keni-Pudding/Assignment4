using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
