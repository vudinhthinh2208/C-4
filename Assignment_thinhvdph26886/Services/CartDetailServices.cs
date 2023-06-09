using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_thinhvdph26886.Services
{
    public class CartDetailServices : ICartDetailServices
    {
        ShoppingDbContext context;
        public CartDetailServices()
        {
            context = new ShoppingDbContext();
        }
        public bool CreateCartDetail(CartDetails i)
        {
            try
            {
                context.CartDetails.Add(i);
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
                var bill = context.CartDetails.FirstOrDefault(p => p.ID == id);
                if (bill != null)
                {
                    context.CartDetails.Remove(bill);
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<CartDetails> GetAllCartDetails()
        {
            return context.CartDetails.Include("Product").ToList();
        }

        public CartDetails GetCartDetailById(Guid id)
        {
            return context.CartDetails.FirstOrDefault(c => c.ID == id);
        }

        public bool UpdateCartDetail(CartDetails i)
        {
            try
            {
                var x = context.CartDetails.FirstOrDefault(p => p.ID == i.ID);
                x.UserID = i.UserID;
                x.IDSP = i.IDSP;
                x.Quantity = i.Quantity;
                context.CartDetails.Update(x);
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
