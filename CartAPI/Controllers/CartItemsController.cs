using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartAPI.CartProducts;
using CartAPI.Service;

namespace CartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartService _context;

        public CartItemsController(ICartService context)
        {
            _context = context;
        }

        // GET: api/CartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItems()
        {
            return await _context.getAllItems();
        }
        [HttpGet]
        [Route("Get{uid}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItembyUserID(string uid)
        {
            List<CartItem> ld=await _context.getItemsbyuserid(uid);
            if (ld == null || ld.Count()==0)
            {
                return BadRequest();
            }
            else
            {
                return ld;
            }
        }

        // GET: api/CartItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartItem>> GetCartItem(int id)
        {
            var cartItem = await _context.getItemById(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            return cartItem;
        }

        // PUT: api/CartItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartItem(int id, CartItem cartItem)
        {
            bool b = false;
            try
            {
                b = _context.EditItems(id, cartItem);
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

        // POST: api/CartItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            bool b = false;
            try
            {
                b = _context.AddItems(cartItem);
                if (b == false)
                {
                    return BadRequest();
                }
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
            return CreatedAtAction("GetCartItem", new { id = cartItem.CartItemId }, cartItem);
        }

        // DELETE: api/CartItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            bool b = _context.DeleteItems(id);
            if (b == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
