using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BBankTestTask.Models;

namespace BBankTestTask.Pages
{
    public class CreateModel : PageModel
    {
        private readonly BBankTestTask.Models.BBankContext _context;

        public CreateModel(BBankTestTask.Models.BBankContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryName"] = new SelectList(_context.Categories, "CategoryName", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ShowProducts");
        }
    }
}
