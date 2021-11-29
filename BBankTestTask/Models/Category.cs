using System;
using System.Collections.Generic;

#nullable disable

namespace BBankTestTask.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CategoryName { get; set; }
        public string CategotyDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
