using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.TakeBillServices
{
    public class TakeBillRepository : ITakeBillRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public TakeBillRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateTakeBill(TakeBill takeBill)
        {
            if (takeBill == null)
            {
                throw new ArgumentNullException(nameof(takeBill));
            }
            _drugDbContext.TakeBills.Add(takeBill);
        }

        public void DeleteTakeBill(TakeBill takeBill)
        {
            _drugDbContext.TakeBills.Remove(takeBill);
        }

        public async Task<IEnumerable<TakeBill>> GetTakeBill()
        {
            return await _drugDbContext.TakeBills.ToListAsync();
        }

        public async Task<TakeBill> GetTakeBillById(int Id)
        {
            return await _drugDbContext.TakeBills.Where(t => t.TakeBillId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> TakeBillExist(int Id)
        {
            return await _drugDbContext.TakeBills.AnyAsync(t => t.TakeBillId == Id);
        }

        public void UpdateTakeBill(TakeBill takeBill, int Id)
        {
            
        }
    }
}
