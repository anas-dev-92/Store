using AutoMapper;
using CompanyStores.Entities;
using CompanyStores.Models.ProductCategory;
using DrugStore;
using DrugStore.Entities;
using DrugStore.Model.ProductModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyStores.Services.ProductCategory
{
    public class ProductCategorysRepository:IProductCategory
    {
        private readonly DrugDbContext drugDb;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;

        public ProductCategorysRepository(DrugDbContext drugDb, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.drugDb = drugDb;
            this.httpContextAccessor = httpContextAccessor;
            this.mapper = mapper;
        }
        public async Task<ServicesResponse<ProductForGet>> AddProductCategory(AddProductCategory newProductCategory)
        {
            ServicesResponse<ProductForGet> servicesResponse = new ServicesResponse<ProductForGet>();
            try
            {
                Product products = new Product
                {
                    ProductName = newProductCategory.ProductName,
                    Company = newProductCategory.Company,
                    Price = newProductCategory.Price,
                    Quantity = newProductCategory.Quantity,
                    BarCode = newProductCategory.BarCode,
                    CompanyStoresId = newProductCategory.CompanyStoresId
                };
                drugDb.Products.Add(products);

                if (products == null)
                {
                    servicesResponse.Success = false;
                    servicesResponse.Message = "ProductNotFound";
                    return servicesResponse;
                }
                //if i want to add new category with the product
                //Category category = new Category
                //{
                //    CategoryName = newProductCategory.CategoryName
                //};
                //drugDb.Categories.Add(category);
                Category category = await drugDb.Categories.FirstOrDefaultAsync(c => c.CategoryId == newProductCategory.CategoryId);
                if (category == null)
                {
                    servicesResponse.Success = false;
                    servicesResponse.Message = "CategoryNotFound";
                    return servicesResponse;
                }
                ProductAndCategory productAndCategory = new ProductAndCategory
                {
                    Products = products,
                    Categories=category
                };
                await drugDb.ProductCategories.AddAsync(productAndCategory);
                await drugDb.SaveChangesAsync();
                servicesResponse.Data = mapper.Map<ProductForGet>(products);
            }
            catch (Exception ex)
            {
                servicesResponse.Success = false;
                servicesResponse.Message = ex.Message;
            }
            return servicesResponse;
        }

        public bool CreateProductCategory(List<int> ProductId, Category category)
        {
            var product = drugDb.Products.Where(p => ProductId.Contains(p.ProductId)).ToList();
            foreach (var prod in product)
            {
                var productcategory = new ProductAndCategory()
                {
                    Products = prod,
                    Categories = category

                };
                drugDb.ProductCategories.Add(productcategory);
            }
            drugDb.Add(category);
            return save();
        }
        public bool save()
        {
            var saved = drugDb.SaveChanges();
            return saved >= 0 ? true : false;
        }

        //    public void CreateProductCategory(AddProductCategory addProductCategory)
        //{
        //    var Category = new Category
        //    {
        //        CategoryName = addProductCategory.CategoryName
        //    };
        //    var product = new Products
        //    {
        //        ProductName = addProductCategory.ProductName,
        //        Company = addProductCategory.Company,
        //        Price = addProductCategory.Price,
        //        Quantity = addProductCategory.Quantity,
        //        Description = addProductCategory.Description,
        //        ProductImage = addProductCategory.ProductImage,
        //        Code = addProductCategory.Code

        //    };
        //    Category.ProductCategory = new List<ProductAndCategory>
        //        {
        //             new ProductAndCategory {
        //               Products = product,
        //               Categories = Category
        //                 }
        //       };

        //    //Now add this book, with all its relationships, to the database
        //    drugDb.Categories.Add(Category);
        //}

        public async Task<bool> SaveChanges()
        {
            return (await drugDb.SaveChangesAsync() > 0);
        }
    }
}
