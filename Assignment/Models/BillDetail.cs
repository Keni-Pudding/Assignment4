using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class BillDetail
    {
        [Key]
        public Guid ID { get; set; }
        public Guid IDHD { get; set; }
        public Guid IDSP { get; set; }
        public int Quantily { get; set; }
        public int Price { get; set; }

        public virtual Bill Bill {get; set; }

        public virtual Product Products { get; set; }
    }
}
