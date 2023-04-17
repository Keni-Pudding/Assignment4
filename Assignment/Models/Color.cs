using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;
using MessagePack;

namespace Assignment.Models
{
    public class Color
    {
        
        public Guid ID { get; set; } 
        public string NameColor { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
