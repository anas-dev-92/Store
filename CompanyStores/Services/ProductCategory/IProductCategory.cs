using CompanyStores.Entities;
using CompanyStores.Models.ProductCategory;
using DrugStore.Entities;
using DrugStore.Model.CategoryModel;
using DrugStore.Model.ProductModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyStores.Services.ProductCategory
{
    public interface IProductCategory
    {
        //Task<ServicesResponse<ProductForGet>> AddProductCategory(AddProductCategory newProductCategory);
        //Task<ProductAndCategory> CreateProductCategory(AddProductCategory addProductCategory);
        //void CreateProductCategory(AddProductCategory addProductCategory);
        //bool CreateProductCategory( CategoryForCreate category);
        //bool save();
        Task<bool> SaveChanges();
    }
}
