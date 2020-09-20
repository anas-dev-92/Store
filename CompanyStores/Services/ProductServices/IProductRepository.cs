using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.ProductServices
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetProduct();
        Task<Products> GetProductById(int Id);
        void CreateProduct(Products products);
        void UpdateProduct(Products products, int Id);
        void DeleteProduct(Products products);
        Task<bool> ProductExist(int Id);
        Task<bool> SaveChanges();
    }
}
