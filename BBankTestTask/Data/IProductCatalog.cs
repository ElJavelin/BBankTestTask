using BBankTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBankTestTask.Data
{
    public interface IProductCatalog
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
