namespace Task01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CreateProductViewModel
    {
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Currency")]
        [Required]
        public decimal? UnitPrice { get; set; }

        [Range(0, 100, ErrorMessage = "Out of range!")]
        [Required]
        public int? Discount { get; set; }

        [Display(Name = "Currency")]
        public decimal? ExtendedPrice { get; set; }

        [Required]
        public short? Quantity { get; set; }
    }
}