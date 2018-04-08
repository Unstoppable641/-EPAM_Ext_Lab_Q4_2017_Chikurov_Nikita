namespace DAL.Components
{
    using System;

    public class Product
    {
        public string ProductName { get; set; }

        public int ProductID { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? Discount { get; set; }

        public decimal? ExtendedPrice { get; set; }

        public int? Total { get; set; }

        public short? Quantity { get; set; }
    }
}
