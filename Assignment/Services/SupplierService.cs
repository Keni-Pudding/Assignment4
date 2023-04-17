using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class SupplierService : ISupplierService
    {
        AssDbContext context= new AssDbContext();
        public bool CreateSupplier(Supplier s)
        {
            try
            {
                context.Suppliers.Add(s);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteSupplier(Guid id)
        {
            try
            {
                var supplier = context.Suppliers.Find(id);
                context.Suppliers.Remove(supplier);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Supplier> GetAllSupplier()
        {
           return context.Suppliers.ToList();   
        }

        public Supplier GetSupplierById(Guid id)
        {
            return context.Suppliers.FirstOrDefault(p => p.Id == id);
        }

        public List<Supplier> GetSupplierByName(string name)
        {
            return context.Suppliers.Where(p=>p.Name.Contains(name)).ToList();
        }

        public bool UpdateSupplier(Supplier s)
        {
            try
            {
                var supplier = context.Suppliers.Find(s.Id);
                supplier.Name = s.Name;
                supplier.Description = s.Description;
                supplier.Status = s.Status;
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
