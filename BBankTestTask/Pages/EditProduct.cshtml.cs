using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BBankTestTask.Models;

namespace BBankTestTask.Pages
{
    public class EditProductModel : PageModel
    {
        private readonly BBankTestTask.Models.BBankContext _context;

        public EditProductModel(BBankTestTask.Models.BBankContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.CategoryNameNavigation).FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }
           ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./ShowProducts");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
