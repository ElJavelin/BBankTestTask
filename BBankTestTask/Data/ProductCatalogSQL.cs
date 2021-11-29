using BBankTestTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBankTestTask.Data
{
    public class ProductCatalogSQL : IProductCatalog
    {
        private BBankContext BBankContext { get; }

        public ProductCatalogSQL(BBankContext bBankContext)
        {
            BBankContext = bBankContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await BBankContext.Products.ToListAsync();
        }
    }
}
