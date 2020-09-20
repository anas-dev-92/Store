using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CategoryServices
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Categories>> GetCategory();
        Task<Categories> GetCategoryById(int Id);
        void CreateCategory(Categories categories);
        void UpdateCategory(Categories categories, int Id);
        void DeleteCategory(Categories categories);
        Task<bool> CategoryExist(int Id);
        Task<bool> SaveChanges();
    }
}
