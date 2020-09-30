using CompanyStores.Entities;
using CompanyStores.Models.CustomerInvoiceModel;
using DrugStore.Entities;
using DrugStore.Model.InvoiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CustomerInvoiceServices
{
    public interface ICustomerInvoiceRepository
    {
        Task<IEnumerable<CustomerInvoice>> GetCustomerInvoice();
        //Task<ServicesResponse<InvoiceForGet>> AddCustomerInvoice(AddCustomerInvoice addCustomerInvoice);
        //bool CreateInvoice(List<int> ProductId, Invoice invoice);
        Task<CustomerInvoice> GetCustomerInvoiceById(int Id);
        void CreateCustomerInvoice(CustomerInvoice customerInvoice);
        void UpdateCustomerInvoice(CustomerInvoice customerInvoice, int Id);
        void DeleteCustomerInvoice(CustomerInvoice customerInvoice);
        Task<bool> CustomerInvoiceExist(int Id);
        Task<bool> SaveChanges();
    }
}
