﻿namespace Assignment_thinhvdph26886.Models
{
    public class BillDetails
    {
        public Guid Id { get; set; }
        public Guid IdHD { get; set; }
        public Guid IdSP { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Product Product { get; set; }
    }
}
