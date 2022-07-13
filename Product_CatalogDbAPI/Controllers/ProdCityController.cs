using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_CatalogDbAPI.ProductCatalogDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_CatalogDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdCityController : ControllerBase
    {
        private readonly ProductRentalContext _context;

        public ProdCityController(ProductRentalContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdCity>>> GetCities()
        {
            return _context.ProdCities.ToList();
        }
    }
}
