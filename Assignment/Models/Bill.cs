using System.ComponentModel.DataAnnotations;
using MessagePack;

namespace Assignment.Models
{
    public class Bill
    {

        
        public Guid ID { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }

        public virtual User User { get; set; }
        public virtual List<BillDetail> BillDetails { get;set; }


    }
}
