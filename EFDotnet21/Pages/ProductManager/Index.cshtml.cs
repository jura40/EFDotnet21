using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDotnet21.Models;

namespace EFDotnet21.Pages.ProductManager
{
    public class IndexModel : PageModel
    {
        private readonly EFDotnet21.Models.BikeStoresContext _context;

        public IndexModel(EFDotnet21.Models.BikeStoresContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category).ToListAsync();
        }
    }
}
