using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;


namespace Assignment_thinhvdph26886.Services
{
    public class BillDetailServices : IBillDetailServices
    {
        ShoppingDbContext context;
        public BillDetailServices()
        {
            context = new ShoppingDbContext();
        }
        public bool CreateBillDetail(BillDetails i)
        {
            try
            {
                context.BillDetails.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBillDetail(Guid id)
        {
            try
            {
                var bill = context.BillDetails.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.BillDetails.Remove(bill);
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

        public List<BillDetails> GetAllBillDetails()
        {
            return context.BillDetails.ToList();
        }

        public BillDetails GetBillDetailById(Guid id)
        {
            return context.BillDetails.FirstOrDefault(c => c.Id == id);
        }

        public List<BillDetails> GetBillDetailsByID(Guid id)
        {
            return context.BillDetails.Where(c => c.IdHD == id).ToList();
        }

        public bool UpdateBillDetail(BillDetails i)
        {
            try
            {
                var x = context.BillDetails.FirstOrDefault(p => p.Id == i.Id);
                x.IdHD = i.IdHD;
                x.IdSP = i.IdSP;
                x.Price = i.Price;
                x.Quantity = i.Quantity;
                context.BillDetails.Update(x);
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
