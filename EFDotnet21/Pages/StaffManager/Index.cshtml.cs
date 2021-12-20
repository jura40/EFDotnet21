using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EFDotnet21.Models;

namespace EFDotnet21.Pages.StafManager
{
    public class IndexModel : PageModel
    {
        private readonly EFDotnet21.Models.BikeStoresContext _context;

        public IndexModel(EFDotnet21.Models.BikeStoresContext context)
        {
            _context = context;
        }

        public IList<Staff> Staff { get;set; }

        public async Task OnGetAsync()
        {
            Staff = await _context.Staffs
                .Include(s => s.Manager)
                .Include(s => s.Orders)
                .Include(s => s.Store).ToListAsync();
        }
    }
}
