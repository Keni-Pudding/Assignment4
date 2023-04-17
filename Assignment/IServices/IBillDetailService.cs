using Assignment.Models;

namespace Assignment.IServices
{
    public interface IBillDetailService
    {
        public bool CreateBillDetail(BillDetail bd);
        public bool UpdateBillDetail(BillDetail bd);
        public bool DeleteUser(Guid id);

        public List<BillDetail> GetAllBillDetail();
        public BillDetail GetBillDetailById(Guid id);
        public List<BillDetail> GetBillDetailByName(string name);
    }
}
