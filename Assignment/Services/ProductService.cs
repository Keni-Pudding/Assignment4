using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
	public class ProductService : IProductService
	{
		AssDbContext context = new AssDbContext();
		public bool CreateProdcut(Product p)
		{
			try
			{
				context.Products.Add(p);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteProduct(Guid id)
		{
			try
			{
				var product = context.Products.Find(id);
				context.Products.Remove(product);
				context.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public List<Product> GetAllProduct()
		{
			return context.Products.Where(p => p.Status < 3).ToList();
		}

		public Product GetProductById(Guid id)
		{
			return context.Products.FirstOrDefault(p => p.ID == id);
		}

		public List<Product> GetProductByName(string name)
		{
			return context.Products.Where(p => p.Name.Contains(name)).ToList();

		}


		public bool UpdateProduct(Product p)
		{
			try
			{
				var product = context.Products.Find(p.ID);
				product.Name = p.Name;
				product.Image = p.Image;
				product.Price = p.Price;
				product.SupplierId= p.SupplierId;
				product.AvailableQuanlity = p.AvailableQuanlity;
				product.ColorId= p.ColorId;
				product.Description= p.Description;
				product.SizeId=p.SizeId;
				product.CatagoryId= p.CatagoryId;
				product.Status = p.Status;
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
