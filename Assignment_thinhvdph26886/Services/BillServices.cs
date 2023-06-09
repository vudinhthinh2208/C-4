using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;


namespace Assignment_thinhvdph26886.Services
{
    public class BillServices : IBillServices
    {
        ShoppingDbContext context;

        public BillServices()
        {
            context = new ShoppingDbContext();
        }
        public bool CreateBill(Bill i)
        {
            try
            {
                context.Bills.Add(i);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBill(Guid id)
        {
            try
            {
                var bill = context.Bills.FirstOrDefault(p => p.Id == id);
                if (bill != null)
                {
                    context.Bills.Remove(bill);
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

        public List<Bill> GetAllBills()
        {
            return context.Bills.ToList();
        }

        public Bill GetBillById(Guid id)
        {
            return context.Bills.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateBill(Bill i)
        {
            try
            {
                var x = context.Bills.FirstOrDefault(p => p.Id == i.Id);
                x.CreateDate = i.CreateDate;
                x.UserID = i.UserID;
                x.Status = i.Status;
                context.Bills.Update(x);
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
