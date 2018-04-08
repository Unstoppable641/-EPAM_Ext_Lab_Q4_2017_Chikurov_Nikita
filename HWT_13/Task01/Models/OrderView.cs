

using System;
using System.ComponentModel.DataAnnotations;

namespace Task01.Models
{
    public class OrderView
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public string OrderStatus { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Sum { get; set; }
    }
}