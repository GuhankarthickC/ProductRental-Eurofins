using CartAPI.CartProducts;
using CartAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _ipr;
        public CartService(ICartRepo ipr)
        {
            _ipr = ipr;
        }
        public bool AddItems(CartItem p)
        {
            bool b=_ipr.AddItems(p);
            return b;
        }

        
        public bool DeleteItems(int pid)
        {
            bool b = _ipr.DeleteItems(pid);
            return b;
        }

        
        public bool EditItems(int id, CartItem p)
        {
            bool flag = _ipr.EditItems(id, p);
            return flag;
        }

        public async Task<List<CartItem>> getAllItems()
        {
            List<CartItem> l = await _ipr.getAllItems();
            return l;
        }

        public async Task<CartItem> getItemById(int id)
        {
            return await _ipr.getItemById(id);
        }

        public async Task<List<CartItem>> getItemsbyuserid(string id)
        {
            List<CartItem> cd=await _ipr.getItemsbyuserid(id);
            return cd;
        }
    }
}
