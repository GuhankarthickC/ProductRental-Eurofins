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
    public class ListedProductsPendingsController : ControllerBase
    {
        private readonly IProdService _context;

        public ListedProductsPendingsController(IProdService context)
        {
            _context = context;
        }

        // GET: api/ListedProductsPendings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListedProductsPending>>> GetListedProductsPendings()
        {
            return await _context.getAllProductsPending();
        }

        // GET: api/ListedProductsPendings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListedProductsPending>> GetListedProductsPending(int id)
        {
            var listedProductpending = await _context.getProdPendingById(id);

            if (listedProductpending == null)
            {
                return NotFound();
            }

            return listedProductpending;
        }

        // PUT: api/ListedProductsPendings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListedProductsPending(int id, ListedProductsPending listedProductsPending)
        {
            bool b = false;
            try
            {
                b = _context.EditProductPending(id, listedProductsPending);
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

        // POST: api/ListedProductsPendings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ListedProductsPending>> PostListedProductsPending(ListedProductsPending listedProductsPending)
        {
            _context.AddProductPending(listedProductsPending);
            return CreatedAtAction("GetListedProductsPending", new { id = listedProductsPending.ProductId }, listedProductsPending);
        }

        // DELETE: api/ListedProductsPendings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListedProductsPending(int id)
        {
            bool b = _context.DeleteProductPending(id);
            if (b == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        
    }
}
