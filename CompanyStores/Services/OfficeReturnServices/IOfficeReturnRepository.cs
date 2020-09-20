using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OfficeReturnServices
{
    public interface IOfficeReturnRepository
    {
        Task<IEnumerable<OfficeReturn>> GetOfficeReturn(int productId);
        Task<OfficeReturn> GetOfficeReturnById(int productId,int Id);
        void CreateOfficeReturn(int productId,OfficeReturn officeReturn);
        void UpdateOfficeReturn(OfficeReturn officeReturn, int Id);
        void DeleteOfficeReturn(OfficeReturn officeReturn);
        Task<bool> OfficeReturnExist(int Id);
        Task<bool> SaveChanges();
    }
}
