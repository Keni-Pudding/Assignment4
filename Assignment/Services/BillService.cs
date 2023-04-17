using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class BillService : IBillService
    {
        AssDbContext context = new AssDbContext();
        public bool CreateBill(Bill b)
        {
            try
            {
                context.Bills.Add(b);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var bill = context.Bills.Find(id);
                context.Bills.Remove(bill);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Bill> GetAllBill()
        {
            return context.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(p => p.ID == id);
        }

        public List<Bill> GetBillByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBill(Bill b)
        {
            try
            {
                var bill = context.Bills.Find(b.ID);
                bill.Status = b.Status;
                context.Bills.Update(bill);
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
