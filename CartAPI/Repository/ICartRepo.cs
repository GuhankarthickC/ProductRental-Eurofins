using CartAPI.CartProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Repository
{
    public interface ICartRepo
    {
        Task<List<CartItem>> getAllItems();
        bool AddItems(CartItem p);
        bool DeleteItems(int pid);
        bool EditItems(int id, CartItem p);
        Task<CartItem> getItemById(int id);
        Task<List<CartItem>> getItemsbyuserid(string id);
    }
}
