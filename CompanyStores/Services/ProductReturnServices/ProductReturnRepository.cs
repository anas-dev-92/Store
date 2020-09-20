using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.ProductReturnServices
{
    public class ProductReturnRepository:IProductReturnRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public ProductReturnRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateProductReturn(int productId,ProductsReturn productsReturn)
        {
            if (productsReturn == null)
            {
                throw new ArgumentNullException(nameof(productsReturn));
            }
            productsReturn.ProductId = productId;
            _drugDbContext.ProductsReturns.Add(productsReturn);
        }

        public void DeleteProductReturn(ProductsReturn productsReturn)
        {
            _drugDbContext.ProductsReturns.Remove(productsReturn);
        }

        public async Task<IEnumerable<ProductsReturn>> GetProductReturn(int productId)
        {
            return await _drugDbContext.ProductsReturns.Where(pr=>pr.ProductId==productId).ToListAsync();
        }

        public async Task<ProductsReturn> GetProductReturnById(int productId,int Id)
        {
            return await _drugDbContext.ProductsReturns.Where(pr => pr.ProductReturnId == Id&&pr.ProductId==productId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> ProductReturnExist(int Id)
        {
            return await _drugDbContext.ProductsReturns.AnyAsync(m => m.ProductReturnId == Id);
        }

        public void UpdateProductReturn(ProductsReturn productsReturn, int Id)
        {

        }
    }
}
