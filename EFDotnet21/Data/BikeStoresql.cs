using EFDotnet21.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDotnet21.Data
{
    public class BikeStoresql : iBikeStore
    {
        private BikeStoresContext BikeStoresContext { get; }

        public BikeStoresql(BikeStoresContext bikeStoresContext)
        {
            BikeStoresContext = bikeStoresContext;
        }



        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await BikeStoresContext.Brands.ToListAsync();
        }
    }
}
