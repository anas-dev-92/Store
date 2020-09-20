using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.BuyInvoiceServices
{
    public interface IBuyInvoiceRepository
    {
        Task<IEnumerable<BuyInvoice>> GetBuyInvoice();
        Task<BuyInvoice> GetBuyInvoiceById(int Id);
        void CreateBuyInvoice(BuyInvoice buyInvoice);
        void UpdateBuyInvoice(BuyInvoice buyInvoice, int Id);
        void DeleteBuyInvoice(BuyInvoice buyInvoice);
        Task<bool> BuyInvoiceExist(int Id);
        Task<bool> SaveChanges();
    }
}
