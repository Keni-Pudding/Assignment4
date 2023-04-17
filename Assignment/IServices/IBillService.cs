
using Assignment.Models;

namespace Assignment.IServices
{
    public interface IBillService
    {
        public bool CreateBill(Bill b);
        public bool UpdateBill(Bill b);
        public bool DeleteBill(Guid id);

        public List<Bill> GetAllBill();
        public Bill GetBillById(Guid id);
        public List<Bill> GetBillByName(string name);
    }
}
