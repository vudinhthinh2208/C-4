using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.IServices
{
    public interface IBillServices
    {
        public bool CreateBill(Bill i);
        public bool UpdateBill(Bill i);
        public bool DeleteBill(Guid id);
        public List<Bill> GetAllBills();
        public Bill GetBillById(Guid id);
    }
}
