using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class CartDetailService : ICartDetailService
    {
        AssDbContext context= new AssDbContext();
        public bool CreateCartDetail(CartDetail cd)
        {
            try
            {
                context.CartDetails.Add(cd);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                var cartDetail = context.CartDetails.Find(id);
                context.CartDetails.Remove(cartDetail);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<CartDetail> GetAllCartDetail()
        {
            return context.CartDetails.ToList();
        }

        public CartDetail GetCartDetailById(Guid id)
        {
            return context.CartDetails.FirstOrDefault(p => p.ID == id);
        }

        public List<CartDetail> GetCartDetailByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCartDetail(CartDetail cd)
        {
            try
            {
                var cartdetail = context.CartDetails.Find(cd.ID);
                cartdetail.ProductId=cd.ProductId;
                cartdetail.Quantity=cd.Quantity;
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
