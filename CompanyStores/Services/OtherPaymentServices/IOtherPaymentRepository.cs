using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OtherPaymentServices
{
    public interface IOtherPaymentRepository
    {
        Task<IEnumerable<OtherPayment>> GetOtherPayment();
        Task<OtherPayment> GetOtherPaymentById(int Id);
        void CreateOtherPayment(OtherPayment otherPayment);
        void UpdateOtherPayment(OtherPayment otherPayment, int Id);
        void DeleteOtherPayment(OtherPayment otherPayment);
        Task<bool> OtherPaymentExist(int Id);
        Task<bool> SaveChanges();
    }
}
