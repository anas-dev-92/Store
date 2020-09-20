using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.TransportInvoiceServices
{
    public class TransportInvoiceRepository : ITransportInvoiceRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public TransportInvoiceRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateTransportInvoice(TransportInvoice transportInvoice)
        {
            if (transportInvoice == null)
            {
                throw new ArgumentNullException(nameof(transportInvoice));
            }
            _drugDbContext.transportInvoices.Add(transportInvoice);
        }

        public void DeleteTransportInvoice(TransportInvoice transportInvoice)
        {
            _drugDbContext.transportInvoices.Remove(transportInvoice);
        }

        public async Task<IEnumerable<TransportInvoice>> GetTransportInvoice()
        {
            return await _drugDbContext.transportInvoices.ToListAsync();
        }

        public async Task<TransportInvoice> GetTransportInvoiceById(int Id)
        {
            return await _drugDbContext.transportInvoices.Where(t => t.TransportInvoiceId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> TransportInvoiceExist(int Id)
        {
            return await _drugDbContext.transportInvoices.AnyAsync(t => t.TransportInvoiceId == Id);
        }

        public void UpdateTransportInvoice(TransportInvoice transportInvoice, int Id)
        {

        }
    }
}
