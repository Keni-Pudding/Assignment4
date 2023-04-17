using Assignment.Models;

namespace Assignment.IServices
{
    public interface ICartDetailService
    {
        public bool CreateCartDetail(CartDetail cd);
        public bool UpdateCartDetail(CartDetail cd);
        public bool DeleteCartDetail(Guid id);

        public List<CartDetail> GetAllCartDetail();
        public CartDetail GetCartDetailById(Guid id);
        public List<CartDetail> GetCartDetailByName(string name);
    }
}
