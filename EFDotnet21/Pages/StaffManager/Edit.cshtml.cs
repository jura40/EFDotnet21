using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFDotnet21.Models;

namespace EFDotnet21.Pages.StafManager
{
    public class EditModel : PageModel
    {
        private readonly EFDotnet21.Models.BikeStoresContext _context;

        public EditModel(EFDotnet21.Models.BikeStoresContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["ManagerId"] = new SelectList(_context.Staffs, "StaffId", "Email");
           ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(Staff.StaffId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
