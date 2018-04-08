using DAL.Components;

namespace Task01.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class IndexOrderViewModel
    {
        public List<OrderView> Orders { get; set; }

        public PageInfo Page { get; set; }
    }
}