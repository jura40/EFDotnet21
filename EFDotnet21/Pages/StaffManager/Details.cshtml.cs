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
    public class DetailsModel : PageModel
    {
        private readonly EFDotnet21.Models.BikeStoresContext _context;

        public DetailsModel(EFDotnet21.Models.BikeStoresContext context)
        {
            _context = context;
        }

        public Staff Staff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Staff = await _context.Staffs
                .Include(s => s.Manager)
                .Include(s => s.Store).FirstOrDefaultAsync(m => m.StaffId == id);

            if (Staff == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
