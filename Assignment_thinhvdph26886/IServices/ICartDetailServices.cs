using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.IServices
{
    public interface ICartDetailServices
    {
        public bool CreateCartDetail(CartDetails i);
        public bool UpdateCartDetail(CartDetails i);
        public bool DeleteCartDetail(Guid id);
        public List<CartDetails> GetAllCartDetails();
        public CartDetails GetCartDetailById(Guid id);
    }
}
