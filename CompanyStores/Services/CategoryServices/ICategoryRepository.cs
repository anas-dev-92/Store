using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CategoryServices
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategoryById(int Id);
        void CreateCategory(Category categories);
        void UpdateCategory(Category categories, int Id);
        void DeleteCategory(Category categories);
        Task<bool> CategoryExist(int Id);
        Task<bool> SaveChanges();
    }
}
