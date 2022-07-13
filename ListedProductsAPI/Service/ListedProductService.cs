using ListedProductsAPI.ListedProducts;
using ListedProductsAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListedProductsAPI.Service
{
    public class ListedProductService : IProdService
    {
        private readonly IProdRepo _ipr;
        public ListedProductService(IProdRepo ipr)
        {
            _ipr = ipr;
        }
        public void AddProduct(ListedProduct p)
        {
            _ipr.AddProduct(p);
        }

        public void AddProductPending(ListedProductsPending p)
        {
            _ipr.AddProductPending(p);
        }

        public bool DeleteProduct(int pid)
        {
            bool b=_ipr.DeleteProduct(pid);
            return b;
        }

        public bool DeleteProductPending(int pid)
        {
            bool b = _ipr.DeleteProductPending(pid);
            return b;
        }

        public bool EditProduct(int id, ListedProduct p)
        {
            bool flag=_ipr.EditProduct(id,p);
            return flag;
        }

        public bool EditProductPending(int id, ListedProductsPending p)
        {
            bool flag = _ipr.EditProductPending(id, p);
            return flag;
        }

        public async Task<List<ListedProduct>> getAllProducts()
        {
            List<ListedProduct> l = await _ipr.getAllProducts();
            return l;
        }

        public async Task<List<ListedProductsPending>> getAllProductsPending()
        {
            List<ListedProductsPending> l = await _ipr.getAllProductsPending();
            return l;
        }

        public async Task<List<ListedProduct>> getbycategory(string category)
        {
            List<ListedProduct> l= await _ipr.getbycategory(category);
            return l;
        }

        public async Task<ListedProduct> getProdById(int id)
        {
            return await _ipr.getProdById(id);
        }

        public async Task<ListedProductsPending> getProdPendingById(int id)
        {
            return await _ipr.getProdPendingById(id);
        }
    }
}
