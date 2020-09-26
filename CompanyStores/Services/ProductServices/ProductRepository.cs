using DrugStore.Entities;
using DrugStore.Model.ProductModel;
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
        public void CreateProduct(ProductForCreate productForCreate)
        {
            Category category;
            category = _drugDbContext.Categories.Find(productForCreate.CategoryId);
            var product = new Product
            {
                ProductName = productForCreate.ProductName,
                Company = productForCreate.Company,
                Price = productForCreate.Price,
                Quantity = productForCreate.Quantity,
                BarCode = productForCreate.BarCode,
                CompanyStoresId = productForCreate.CompanyStoresId
            };
            category.ProductCategory.Add(new ProductAndCategory { Products = product });
            _drugDbContext.Categories.Attach(category);
            _drugDbContext.SaveChanges();
        }

        public void DeleteProduct(Product products)
        {
            _drugDbContext.Products.Remove(products);
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _drugDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int Id)
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

        public void UpdateProduct(Product products, int Id)
        {

        }

    }
}
