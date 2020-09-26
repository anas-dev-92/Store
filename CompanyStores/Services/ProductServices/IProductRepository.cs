using DrugStore.Entities;
using DrugStore.Model.ProductModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.ProductServices
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetProductById(int Id);
        void CreateProduct(ProductForCreate productForCreate);
        void UpdateProduct(Product products, int Id);
        void DeleteProduct(Product products);
        Task<bool> ProductExist(int Id);
        Task<bool> SaveChanges();
    }
}
