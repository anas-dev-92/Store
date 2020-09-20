using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.TakeBillServices
{
    public interface ITakeBillRepository
    {
        Task<IEnumerable<TakeBill>> GetTakeBill();
        Task<TakeBill> GetTakeBillById(int Id);
        void CreateTakeBill(TakeBill takeBill);
        void UpdateTakeBill(TakeBill takeBill, int Id);
        void DeleteTakeBill(TakeBill takeBill);
        Task<bool> TakeBillExist(int Id);
        Task<bool> SaveChanges();
    }
}
