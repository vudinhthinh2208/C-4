﻿namespace Assignment_thinhvdph26886.Models
{
    public class CartDetails
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid IDSP { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
