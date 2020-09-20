using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CompanyStoreervices
{
    public class CompanyStoreRepository : ICompanyStoreRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public CompanyStoreRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateCompanyStore(CompanyStore drugStores)
        {
            _drugDbContext.CompanyStore.Add(drugStores);
        }

        public void DeleteCompanyStore(CompanyStore CompanyStore)
        {
            _drugDbContext.Remove(CompanyStore);
        }

        public bool CompanyStoreExist(int Id)
        {
            return _drugDbContext.CompanyStore.Any(d => d.CompanyStoresId == Id);
        }

        public async Task<IEnumerable<CompanyStore>> GetCompanyStore()
        {
            return await _drugDbContext.CompanyStore.ToListAsync();
        }

        public CompanyStore GetCompanyStoreById(int Id)
        {
            return _drugDbContext.CompanyStore.FirstOrDefault(d => d.CompanyStoresId == Id);
        }

        public void SaveChanges()
        {
            _drugDbContext.SaveChanges();
        }

        public void UpdateCompanyStore(CompanyStore CompanyStore, int Id)
        {

        }
    }
}
