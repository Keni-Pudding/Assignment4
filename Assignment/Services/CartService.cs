using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class CartService : ICartService
    {
        AssDbContext context = new AssDbContext();
        public bool CreateCart(Cart c)
        {
            try
            {
                context.Carts.Add(c);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                var cart = context.Carts.Find(id);
                context.Carts.Remove(cart);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Cart> GetAllCart()
        {
            return context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.FirstOrDefault(p => p.UserID == id);
        }

        public List<Cart> GetCartByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCart(Cart c)
        {
            try
            {
                var cart = context.Carts.Find(c.UserID);
                cart.Description = c.Description;
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
