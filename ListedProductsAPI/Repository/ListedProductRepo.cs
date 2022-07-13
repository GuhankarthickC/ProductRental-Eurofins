using ListedProductsAPI.ListedProducts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListedProductsAPI.Repository
{
    public class ListedProductRepo : IProdRepo
    {
        private readonly ProductRentalContext _context;

        public ListedProductRepo(ProductRentalContext context)
        {
            _context = context;
        }
        public void AddProduct(ListedProduct p)
        {
            _context.ListedProducts.Add(p);
            _context.SaveChangesAsync();
        }

        public void AddProductPending(ListedProductsPending p)
        {
            _context.ListedProductsPendings.Add(p);
            _context.SaveChangesAsync();
        }

        public bool DeleteProduct(int id)
        {
            var listedProduct = _context.ListedProducts.Find(id);
            if (listedProduct == null)
            {
                return false;
            }
            else
            {
                _context.ListedProducts.Remove(listedProduct);
                _context.SaveChanges();
                return true;
            }
            
        }

        public bool DeleteProductPending(int pid)
        {
            var listedProductPending = _context.ListedProductsPendings.Find(pid);
            if (listedProductPending == null)
            {
                return false;
            }
            else
            {
                _context.ListedProductsPendings.Remove(listedProductPending);
                _context.SaveChanges();
                return true;
            }
        }

        public bool EditProduct(int id,ListedProduct p)
        {
            bool flag=false;
            _context.Entry(p).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListedProductExists(id))
                {
                    flag= false;
                }
                else
                {
                    flag=true;
                }
            }
            return flag;
        }

        public bool EditProductPending(int id, ListedProductsPending p)
        {
            bool flag = false;
            _context.Entry(p).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListedProductsPendingExists(id))
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

        public async Task<List<ListedProduct>> getAllProducts()
        {
            List<ListedProduct> l= await _context.ListedProducts.ToListAsync();
            return l;
        }

        public async Task<List<ListedProductsPending>> getAllProductsPending()
        {
            List<ListedProductsPending> l = await _context.ListedProductsPendings.ToListAsync();
            return l;
        }

        public async Task<List<ListedProduct>> getbycategory(string category)
        {
            List<ListedProduct> l =await (from i in _context.ListedProducts where i.ProductCategory == category select i).ToListAsync();
            return l;
        }

        public async Task<ListedProduct> getProdById(int id)
        {
            var listedProduct = await _context.ListedProducts.FindAsync(id);
            return listedProduct;
        }

        public async Task<ListedProductsPending> getProdPendingById(int id)
        {
            var listedProductpending = await _context.ListedProductsPendings.FindAsync(id);
            return listedProductpending;
        }

        private bool ListedProductExists(int id)
        {
            return _context.ListedProducts.Any(e => e.ProductId == id);
        }
        private bool ListedProductsPendingExists(int id)
        {
            return _context.ListedProductsPendings.Any(e => e.ProductId == id);
        }
    }
}
