using CompanyStores.Entities;
using CompanyStores.Models.ProductCategory;
using DrugStore.Model.ProductModel;
using System.Threading.Tasks;

namespace CompanyStores.Services.ProductCategory
{
    public interface IProductCategory
    {
        Task<ServicesResponse<ProductForGet>> AddProductCategory(AddProductCategory newProductCategory);
        //Task<ProductAndCategory> CreateProductCategory(AddProductCategory addProductCategory);
        //void CreateProductCategory(AddProductCategory addProductCategory);
        Task<bool> SaveChanges();
    }
}
