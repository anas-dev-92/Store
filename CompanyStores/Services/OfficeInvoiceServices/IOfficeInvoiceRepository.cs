using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OfficeInvoiceServices
{
    public interface IOfficeInvoiceRepository
    {
        Task<IEnumerable<OfficeInvoice>> GetOfficeInvoice(int productId);
        Task<OfficeInvoice> GetOfficeInvoiceById(int productId,int Id);
        void CreateOfficeInvoice(int productId,OfficeInvoice officeInvoice);
        void UpdateOfficeInvoice(OfficeInvoice officeInvoice, int Id);
        void DeleteOfficeInvoice(OfficeInvoice officeInvoice);
        Task<bool> OfficeInvoiceExist(int Id);
        Task<bool> SaveChanges();
    }
}
