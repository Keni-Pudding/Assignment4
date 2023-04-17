using Assignment.Models;

namespace Assignment.IServices
{
    public interface IProductService
    {
        public bool CreateProdcut(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);

        public List<Product> GetAllProduct();
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
    }
}
