using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDotnet21.Data;
using EFDotnet21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFDotnet21.Pages
{
    public class BrandsModel : PageModel
    {
        public List<Brand> Brands;
        private iBikeStore BikeStore { get; }

        public BrandsModel(iBikeStore bikestore)
        {
            BikeStore = bikestore;
        }

       

        public async Task<IActionResult> OnGetAsync()
        {
            var brands = await BikeStore.GetBrands();
            Brands = brands.ToList();
            return Page();
        }
    }
}
