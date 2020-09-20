using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DrugStore.Services.InvoiceServices
{
    public class InvoiceRepository : IinvoiceRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public InvoiceRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void DeleteInvoice(Invoice invoice)
        {
            _drugDbContext.Invoices.Remove(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetInvoice()
        {
            return await _drugDbContext.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceById(int InvoiceId)
        {
            return await _drugDbContext.Invoices.Where(i => i.InvoiceId == InvoiceId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> InvoiceExist(int Id)
        {
            return await _drugDbContext.Invoices.AnyAsync(i => i.InvoiceId == Id);
        }

        public void UpdateInvoice(Invoice invoice, int Id)
        {

        }

        public void CreateInvoice(Invoice invoice)
        {
            _drugDbContext.Invoices.Add(invoice);
        }
    }
}
