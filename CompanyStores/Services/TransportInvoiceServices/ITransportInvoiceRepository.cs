using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.TransportInvoiceServices
{
     public interface ITransportInvoiceRepository
    {
        Task<IEnumerable<TransportInvoice>> GetTransportInvoice();
        Task<TransportInvoice> GetTransportInvoiceById(int Id);
        void CreateTransportInvoice( TransportInvoice transportInvoice);
        void UpdateTransportInvoice(TransportInvoice transportInvoice, int Id);
        void DeleteTransportInvoice(TransportInvoice transportInvoice);
        Task<bool> TransportInvoiceExist(int Id);
        Task<bool> SaveChanges();
    }
}
