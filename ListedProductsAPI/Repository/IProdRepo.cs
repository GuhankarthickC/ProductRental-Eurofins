using ListedProductsAPI.ListedProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListedProductsAPI.Repository
{
    public interface IProdRepo
    {
        Task<List<ListedProduct>> getAllProducts();
        void AddProduct(ListedProduct p);
        bool DeleteProduct(int pid);
        bool EditProduct(int id,ListedProduct p);
        Task<ListedProduct> getProdById(int id);
        Task<List<ListedProductsPending>> getAllProductsPending();
        void AddProductPending(ListedProductsPending p);
        bool DeleteProductPending(int pid);
        bool EditProductPending(int id, ListedProductsPending p);
        Task<ListedProductsPending> getProdPendingById(int id);

        Task<List<ListedProduct>> getbycategory(string category);
    }
}
