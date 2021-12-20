using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFDotnet21.Models;

namespace EFDotnet21.Pages.StafManager
{
    public class CreateModel : PageModel
    {
        private readonly EFDotnet21.Models.BikeStoresContext _context;

        public CreateModel(EFDotnet21.Models.BikeStoresContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ManagerId"] = new SelectList(_context.Staffs, "StaffId", "Email");
        ViewData["StoreId"] = new SelectList(_context.Stores, "StoreId", "StoreName");
            return Page();
        }

        [BindProperty]
        public Staff Staff { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Staffs.Add(Staff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
