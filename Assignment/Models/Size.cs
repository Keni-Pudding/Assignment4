using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Size
    {
        [Key]
        public Guid Id { get; set; }    
        public string NameSize { get; set; }   
        public virtual List<Product> Product { get; set; }
    }
}
