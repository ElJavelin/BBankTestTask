using BBankTestTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBankTestTask.Data
{
    public class CategoryCatalogSQL : ICategoryCatalog
    {
        private BBankContext BBankContext { get; }

        public CategoryCatalogSQL(BBankContext bBankContext)
        {
            BBankContext = bBankContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await BBankContext.Categories.ToListAsync();
        }
    }
}
