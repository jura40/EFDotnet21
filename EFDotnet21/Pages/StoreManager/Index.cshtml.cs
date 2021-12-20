using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDotnet21.Models;

namespace EFDotnet21.Pages.StoreManager
{
    public class IndexModel : PageModel
    {
        private readonly EFDotnet21.Models.BikeStoresContext _context;

        public IndexModel(EFDotnet21.Models.BikeStoresContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get;set; }

        public async Task OnGetAsync()
        {
            Store = await _context.Stores.ToListAsync();
        }
    }
}
