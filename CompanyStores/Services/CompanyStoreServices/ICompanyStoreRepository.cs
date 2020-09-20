using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CompanyStoreervices
{
    public interface ICompanyStoreRepository
    {
       Task<IEnumerable<CompanyStore>> GetCompanyStore();
        CompanyStore GetCompanyStoreById(int Id);
        void CreateCompanyStore(CompanyStore CompanyStore);
        void UpdateCompanyStore(CompanyStore CompanyStore, int Id);
        void DeleteCompanyStore(CompanyStore CompanyStore);
        bool CompanyStoreExist(int Id);
        void SaveChanges();
    }
}
