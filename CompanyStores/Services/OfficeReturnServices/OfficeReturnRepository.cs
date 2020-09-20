using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OfficeReturnServices
{
    public class OfficeReturnRepository:IOfficeReturnRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public OfficeReturnRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateOfficeReturn(int productId,OfficeReturn officeReturn)
        {
            if (officeReturn == null)
            {
                throw new ArgumentNullException(nameof(officeReturn));
            }
            officeReturn.ProductsId = productId;
            _drugDbContext.OfficeReturns.Add(officeReturn);
        }

        public void DeleteOfficeReturn(OfficeReturn officeReturn)
        {
            _drugDbContext.OfficeReturns.Remove(officeReturn);
        }

        public async Task<IEnumerable<OfficeReturn>> GetOfficeReturn(int productId)
        {
            return await _drugDbContext.OfficeReturns.Where(or=>or.ProductsId==productId).ToListAsync();
        }

        public async Task<OfficeReturn> GetOfficeReturnById(int productId,int Id)
        {

            return await _drugDbContext.OfficeReturns.Where(o => o.OfficeReturnId == Id&&o.ProductsId==productId)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> OfficeReturnExist(int Id)
        {
            return await _drugDbContext.OfficeReturns.AnyAsync(o => o.OfficeReturnId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public void UpdateOfficeReturn(OfficeReturn officeReturn, int Id)
        {

        }
    }
}
