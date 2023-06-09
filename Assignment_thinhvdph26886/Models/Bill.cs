namespace Assignment_thinhvdph26886.Models
{
    public class Bill
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserID { get; set; }
        public int Status { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<BillDetails> BillDetails { get; set; }
    }
}
