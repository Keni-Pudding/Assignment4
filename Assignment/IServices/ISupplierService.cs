using Assignment.Models;
namespace Assignment.IServices
{
    public interface ISupplierService
    {
        public bool CreateSupplier(Supplier s);
        public bool UpdateSupplier(Supplier s);
        public bool DeleteSupplier(Guid id);

        public List<Supplier> GetAllSupplier();
        public Supplier GetSupplierById(Guid id);
        public List<Supplier> GetSupplierByName(string name);
    }
}
