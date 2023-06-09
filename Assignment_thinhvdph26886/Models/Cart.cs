namespace Assignment_thinhvdph26886.Models
{
    public class Cart
    {
        public Guid UserID { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual IEnumerable<CartDetails> CartDetails { get; set; }
    }
}
