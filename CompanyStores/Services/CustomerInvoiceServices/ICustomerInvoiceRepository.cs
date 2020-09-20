using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CustomerInvoiceServices
{
    public interface ICustomerInvoiceRepository
    {
        Task<IEnumerable<CustomerInvoice>> GetCustomerInvoice();
        void CreateInvoiceWithProduct(CustomerInvoice customerInvoice);
        Task<CustomerInvoice> GetCustomerInvoiceById(int Id);
        void CreateCustomerInvoice(CustomerInvoice customerInvoice);
        void UpdateCustomerInvoice(CustomerInvoice customerInvoice, int Id);
        void DeleteCustomerInvoice(CustomerInvoice customerInvoice);
        Task<bool> CustomerInvoiceExist(int Id);
        Task<bool> SaveChanges();
    }
}
