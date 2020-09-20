using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CustomerInvoiceServices
{
    public class CustomerInvoiceRepository:ICustomerInvoiceRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public CustomerInvoiceRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateCustomerInvoice(CustomerInvoice customerInvoice)
        {
            _drugDbContext.CustomerInvoices.Add(customerInvoice);
        }

        public void DeleteCustomerInvoice(CustomerInvoice customerInvoice)
        {
            _drugDbContext.CustomerInvoices.Remove(customerInvoice);
        }

        public async Task<IEnumerable<CustomerInvoice>> GetCustomerInvoice()
        {
            return await _drugDbContext.CustomerInvoices.ToListAsync();
        }

        public async Task<CustomerInvoice> GetCustomerInvoiceById(int Id)
        {
            return await _drugDbContext.CustomerInvoices.Where(c => c.CustomerInvoiceId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> CustomerInvoiceExist(int Id)
        {
            return await _drugDbContext.CustomerInvoices.AnyAsync(c => c.CustomerInvoiceId == Id);
        }

        public void UpdateCustomerInvoice(CustomerInvoice customerInvoice, int Id)
        {

        }

        public void CreateInvoiceWithProduct(CustomerInvoice customerInvoice)
        {
            
        }
    }
}
