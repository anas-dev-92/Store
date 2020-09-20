using DrugStore.Entities;
using DrugStore.Services.PaymentBillServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.BillServices
{
    public class PaymentBillRepository:IPaymentBillRepository
    {
        private readonly DrugDbContext _drugDbcontext;

        public PaymentBillRepository(DrugDbContext drugDbContext)
        {
            _drugDbcontext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public async Task<bool> PBillExist(int Id)
        {
            return await _drugDbcontext.PaymentBills.AnyAsync(p =>p.PaymentBillId  == Id);
        }

        public void CreatePaymentBill(PaymentBill payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }
            _drugDbcontext.PaymentBills.Add(payment);

        }

        public void DeletePBill(PaymentBill payment)
        {
            _drugDbcontext.PaymentBills.Remove(payment);
        }

        public async Task<PaymentBill> GetPBillById(int Id)
        {
            //must read if i should use this or use where insted of firstordefault
            return await _drugDbcontext.PaymentBills.FirstOrDefaultAsync(p => p.PaymentBillId == Id);
        }
        
        public async Task<IEnumerable<PaymentBill>> GetPaymentBill()
        {
            return await _drugDbcontext.PaymentBills.ToListAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbcontext.SaveChangesAsync() > 0);
        }

        public void UpdatePaymentBill(PaymentBill payment, int Id)
        {

        }
    }
}
