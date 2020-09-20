using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OfficeInvoiceServices
{
    public class OfficeInvoiceRepository:IOfficeInvoiceRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public OfficeInvoiceRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateOfficeInvoice(int productId,OfficeInvoice officeInvoice)
        {
            if (officeInvoice == null)
            {
                throw new ArgumentNullException(nameof(officeInvoice));
            }
            officeInvoice.ProductsId = productId;
            _drugDbContext.OfficeInvoices.Add(officeInvoice);
        }

        public void DeleteOfficeInvoice(OfficeInvoice officeInvoice)
        {
            _drugDbContext.OfficeInvoices.Remove(officeInvoice);
        }

        public async Task<IEnumerable<OfficeInvoice>> GetOfficeInvoice(int productId)
        {
            return await _drugDbContext.OfficeInvoices.Where(oi=>oi.ProductsId==productId).ToListAsync();
        }

        public async Task<OfficeInvoice> GetOfficeInvoiceById(int productId,int Id)
        {

            return await _drugDbContext.OfficeInvoices.Where(o => o.OfficeInvoiceId == Id&&o.ProductsId==productId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> OfficeInvoiceExist(int Id)
        {
            return await _drugDbContext.OfficeInvoices.AnyAsync(o => o.OfficeInvoiceId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public void UpdateOfficeInvoice(OfficeInvoice officeInvoice, int Id)
        {

        }
    }
}
