using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.ProductServices
{
    public class ProductRepository : IProductRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public ProductRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateProduct(Products products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }
            _drugDbContext.Products.Add(products);
        }

        public void DeleteProduct(Products products)
        {
            _drugDbContext.Products.Remove(products);
        }

        public async Task<IEnumerable<Products>> GetProduct()
        {
            return await _drugDbContext.Products.ToListAsync();
        }

        public async Task<Products> GetProductById(int Id)
        {

            return await _drugDbContext.Products.Where(p => p.ProductId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ProductExist(int Id)
        {
            return await _drugDbContext.Products.AnyAsync(m => m.ProductId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public void UpdateProduct(Products products, int Id)
        {

        }

    }
}
