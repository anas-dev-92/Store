using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.InvoiceServices
{
    public interface IinvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetInvoice();
        Task<Invoice> GetInvoiceById(int Id);
        void CreateInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice, int Id);
        void DeleteInvoice(Invoice invoice);
        Task<bool> InvoiceExist(int Id);
        Task<bool> SaveChanges();
    }
}
