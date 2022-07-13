using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListedProductsAPI.ListedProducts;
using ListedProductsAPI.Service;

namespace ListedProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListedProductsController : ControllerBase
    {
        private readonly IProdService _context;

        public ListedProductsController(IProdService context)
        {
            _context = context;
        }

        // GET: api/ListedProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListedProduct>>> GetListedProducts()
        {
            return await _context.getAllProducts();
        }

        // GET: api/ListedProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListedProduct>> GetListedProduct(int id)
        {
            var listedProduct = await _context.getProdById(id);

            if (listedProduct == null)
            {
                return NotFound();
            }

            return listedProduct;
        }
        [HttpGet("getbycategory{category}")]
        public async Task<ActionResult<List<ListedProduct>>> GetListedProductbyCategory(string category)
        {
             List<ListedProduct> l = await _context.getbycategory(category);

            if (l.Count() == 0)
            {
                return NotFound();
            }

            return l;
        }

        // PUT: api/ListedProducts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListedProduct(int id, ListedProduct listedProduct)
        {
            bool b = false ;
            try
            {
                 b= _context.EditProduct(id, listedProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!b)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ListedProducts
        [HttpPost]
        public async Task<ActionResult<ListedProduct>> PostListedProduct(ListedProduct listedProduct)
        {
           _context.AddProduct(listedProduct);
            return CreatedAtAction("GetListedProduct", new { id = listedProduct.ProductId }, listedProduct);
        }

        // DELETE: api/ListedProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListedProduct(int id)
        {
            bool b=_context.DeleteProduct(id);
            if (b == false)
            {
                return NotFound();
            }
            return NoContent();
        }

       
    }
}
