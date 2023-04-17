using System.ComponentModel.DataAnnotations;

namespace Assignment.Models
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int AvailableQuanlity { get; set; }
        public Guid CatagoryId { get; set; }
        public Guid SupplierId { get; set; }
       
        

        public Guid SizeId { get; set; }
        public Guid ColorId { get; set; }

      
        public int Status { get; set; }

        public virtual List<CartDetail> CartDetails { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual Size Size { get; set; }
        public virtual Color Color { get; set; }

        
        public virtual Category Category { get; set; }
        public virtual List<BillDetail> BillDetails { get; set; }
       


    }
}
