using EFDotnet21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFDotnet21.Data
{
    public interface iBikeStore
    {
        Task<IEnumerable<Brand>> GetBrands();
    }
}
