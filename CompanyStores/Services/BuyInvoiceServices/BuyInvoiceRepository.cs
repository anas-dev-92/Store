using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.BuyInvoiceServices
{
    public class BuyInvoiceRepository:IBuyInvoiceRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public BuyInvoiceRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateBuyInvoice(BuyInvoice buyInvoice)
        {
            if (buyInvoice == null)
            {
                throw new ArgumentNullException(nameof(buyInvoice));
            }
            _drugDbContext.BuyInvoices.Add(buyInvoice);
        }

        public void DeleteBuyInvoice(BuyInvoice buyInvoice)
        {
            _drugDbContext.BuyInvoices.Remove(buyInvoice);
        }

        public async Task<IEnumerable<BuyInvoice>> GetBuyInvoice()
        {
            return await _drugDbContext.BuyInvoices.ToListAsync();
        }

        public async Task<BuyInvoice> GetBuyInvoiceById(int Id)
        {
            return await _drugDbContext.BuyInvoices.SingleOrDefaultAsync(b => b.BuyInvoiceId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> BuyInvoiceExist(int Id)
        {
            return await _drugDbContext.BuyInvoices.AnyAsync(b => b.BuyInvoiceId == Id);
        }

        public void UpdateBuyInvoice(BuyInvoice buyInvoice, int Id)
        {

        }
    }
}
