using CartAPI.CartProducts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Repository
{
    public class CartRepository : ICartRepo
    {
        private readonly ProductRentalContext _context;

        public CartRepository(ProductRentalContext context)
        {
            _context = context;
        }
        public bool AddItems(CartItem p)
        {
            CartItem cd = new();
            bool b = true;
            cd=_context.CartItems.Find(p.CartItemId);
            if (cd==null)
            {
                _context.CartItems.Add(p);
                try
                {
                    _context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    throw;
                }
            }
            else
            {
                b = false;
            }
            return b;
       }

        public bool DeleteItems(int id)
        {
            var cartitem = _context.CartItems.Find(id);
            if (cartitem == null)
            {
                return false;
            }
            else
            {
                _context.CartItems.Remove(cartitem);
                _context.SaveChanges();
                return true;
            }

        }

        public bool EditItems(int id, CartItem p)
        {
            bool flag = false;
            _context.Entry(p).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }

       

        public async Task<List<CartItem>> getAllItems()
        {
            List<CartItem> l = await _context.CartItems.ToListAsync();
            return l;
        }

       
        public async Task<CartItem> getItemById(int id)
        {
            var cart = await _context.CartItems.FindAsync(id);
            return cart;
        }

        public async Task<List<CartItem>> getItemsbyuserid(string id)
        {
            List<CartItem> cart = await (from i in _context.CartItems where i.UserId==id select i).ToListAsync();
            return cart;
        }

        private bool CartItemExists(int id)
        {
            return _context.CartItems.Any(e => e.CartItemId == id);
        }
       
    }
}
