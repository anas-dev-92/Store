﻿using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CategoryServices
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public CategoryRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateCategory(Category categories)
        {
            if (categories == null)
            {
                throw new ArgumentNullException(nameof(categories));
            }
            _drugDbContext.Categories.Add(categories);
        }

        public void DeleteCategory(Category categories)
        {
            _drugDbContext.Categories.Remove(categories);
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            return await _drugDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int Id)
        {
            return await _drugDbContext.Categories.SingleOrDefaultAsync(s => s.CategoryId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> CategoryExist(int Id)
        {
            return await _drugDbContext.Categories.AnyAsync(s => s.CategoryId == Id);
        }

        public void UpdateCategory(Category invoice, int Id)
        {

        }
    }
}
