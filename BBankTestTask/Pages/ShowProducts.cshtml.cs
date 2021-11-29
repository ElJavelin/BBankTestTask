using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBankTestTask.Data;
using BBankTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BBankTestTask.Views
{
    public class ProductsModel : PageModel
    {
        public List<Product> Products;
        public List<Category> Categories;

        private IProductCatalog productCatalog { get; }
        private ICategoryCatalog categoryCatalog { get; }

        public ProductsModel(IProductCatalog productCatalog, ICategoryCatalog categoryCatalog)
        {
            this.productCatalog = productCatalog;
            this.categoryCatalog = categoryCatalog;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var products = await productCatalog.GetProducts();
            Products = products.ToList();

            var categories = await categoryCatalog.GetCategories();
            Categories = categories.ToList();

            return Page();
        }
    }
}
