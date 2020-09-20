using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.PaymentBillServices
{
    public interface IPaymentBillRepository
    {
        Task<IEnumerable<PaymentBill>> GetPaymentBill();
        Task<PaymentBill> GetPBillById(int Id);
        void CreatePaymentBill(PaymentBill payment);
        void UpdatePaymentBill(PaymentBill payment, int Id);
        void DeletePBill(PaymentBill payment);
        Task<bool> PBillExist(int Id);
        Task<bool> SaveChanges();
    }
}
