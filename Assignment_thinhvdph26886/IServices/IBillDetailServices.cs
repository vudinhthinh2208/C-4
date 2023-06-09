using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.IServices
{
    public interface IBillDetailServices
    {
        public bool CreateBillDetail(BillDetails i);
        public bool UpdateBillDetail(BillDetails i);
        public bool DeleteBillDetail(Guid id);
        public List<BillDetails> GetAllBillDetails();
        public List<BillDetails> GetBillDetailsByID(Guid IDHD);
        public BillDetails GetBillDetailById(Guid id);
    }
}
