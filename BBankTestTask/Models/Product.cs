using System;
using System.Collections.Generic;

#nullable disable

namespace BBankTestTask.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductGenaralNote { get; set; }
        public string ProductSpeciallNote { get; set; }

        public virtual Category CategoryNameNavigation { get; set; }
    }
}
