using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.ProductReturnServices
{
    public interface IProductReturnRepository
    {
        Task<IEnumerable<ProductsReturn>> GetProductReturn(int productId);
        Task<ProductsReturn> GetProductReturnById(int productId,int Id);
        void CreateProductReturn(int productId,ProductsReturn productsReturn);
        void UpdateProductReturn(ProductsReturn productsReturn, int Id);
        void DeleteProductReturn(ProductsReturn productsReturn);
        Task<bool> ProductReturnExist(int Id);
        Task<bool> SaveChanges();
    }
}
