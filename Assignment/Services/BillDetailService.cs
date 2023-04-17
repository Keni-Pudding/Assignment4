using System.Net.WebSockets;
using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class BillDetailService : IBillDetailService
    {
        AssDbContext context = new AssDbContext();
        public bool CreateBillDetail(BillDetail bd)
        {
            try
            {
                context.BillDetails.Add(bd);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

               return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                var billdetail = context.BillDetails.Find(id);
                context.BillDetails.Remove(billdetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<BillDetail> GetAllBillDetail()
        {
           return context.BillDetails.ToList();
        }

        public BillDetail GetBillDetailById(Guid id)
        {
            return context.BillDetails.FirstOrDefault(p => p.ID == id, null);
        }

        public List<BillDetail> GetBillDetailByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBillDetail(BillDetail bd)
        {
            try
            {
                var billdetail = context.BillDetails.Find(bd.ID);
                billdetail.Quantily=bd.Quantily;
                billdetail.Price=bd.Price;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
