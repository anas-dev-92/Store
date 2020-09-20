using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OfficeServices
{
    public interface IOfficeRepository
    {
        Task<IEnumerable<Office>> GetOffice();
        Task<Office> GetOfficeById(int Id);
        void CreateOffice(Office office);
        void UpdateOffice(Office office, int Id);
        void DeleteOffice(Office office);
        Task<bool> OfficeExist(int Id);
        Task<bool> SaveChanges();
    }
}
