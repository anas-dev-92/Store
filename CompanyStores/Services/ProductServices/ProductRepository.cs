using DrugStore.Entities;
using DrugStore.Model.ProductModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
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
        //public void CreateProduct(ProductForCreate productForCreate)
        //{
        //    List<product> theList = _drugDbContext.Products.Where(c => c.productId == productForCreate.productid).ToList();
        //    var product = new Product
        //    {
        //        ProductName = productForCreate.ProductName,
        //        Company = productForCreate.Company,
        //        Price = productForCreate.Price,
        //        Quantity = productForCreate.Quantity,
        //        BarCode = productForCreate.BarCode,
        //        CompanyStoresId = productForCreate.CompanyStoresId,
        //    };
            
        //    _drugDbContext.Products.Add(product);
        //    _drugDbContext.Categories.Attach(category);
        //    _drugDbContext.SaveChanges();
        //}
        public void CreateProduct(ProductForCreate productForCreate)
        {

            var product = new Product
            {
                ProductName = productForCreate.ProductName,
                Company = productForCreate.Company,
                Price = productForCreate.Price,
                Quantity = productForCreate.Quantity,
                BarCode = productForCreate.BarCode,
                CompanyStoresId = productForCreate.CompanyStoresId,
            };

            _drugDbContext.SaveChanges();
            IList<Category> cate = _drugDbContext.Categories.ToList<Category>();
            var query = from e in cate
                        where productForCreate.categories.Contains(e.CategoryId)
                        select e;
            IList<Category> result = query.ToList<Category>();
            foreach (var item in theList)
            {
                _drugDbContext.ProductCategories.AddRange(
                    new ProductAndCategory
                    {
                        CategoryId = item.CategoryId,
                        ProductId= product.ProductId
                    });
                _drugDbContext.SaveChanges();
            }
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
