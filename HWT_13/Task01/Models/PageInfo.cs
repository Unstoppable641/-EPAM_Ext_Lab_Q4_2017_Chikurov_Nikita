namespace Task01.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PageInfo
    {
        private const int PAGESIZE = 30;

        public int PageNumber { get; set; } 

        public static int PageSize => PAGESIZE;

        public int TotalItems { private get; set; } 

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / PageSize);
    }
}