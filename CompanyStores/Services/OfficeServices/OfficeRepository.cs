using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OfficeServices
{
    public class OfficeRepository:IOfficeRepository
    {
        private readonly DrugDbContext _drugDbcontext;

        public OfficeRepository(DrugDbContext drugDbContext)
        {
            _drugDbcontext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }

        public void CreateOffice(Office office)
        {
            if (office ==null)
            {
                throw new ArgumentNullException(nameof(office));
            }
            _drugDbcontext.Offices.Add(office);
        }

        public void DeleteOffice(Office office)
        {
            _drugDbcontext.Offices.Remove(office);
        }

        public async Task<IEnumerable<Office>> GetOffice()
        {
            return await _drugDbcontext.Offices.ToListAsync();
        }

        public async Task<Office> GetOfficeById(int Id)
        {
            
            return await _drugDbcontext.Offices.SingleOrDefaultAsync(o => o.OfficeId == Id);
        }

        public async Task<bool> OfficeExist(int Id)
        {
            return await _drugDbcontext.Offices.AnyAsync(o => o.OfficeId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbcontext.SaveChangesAsync() > 0);
        }

        public void UpdateOffice(Office office, int Id)
        {
            
        }
    }
}
