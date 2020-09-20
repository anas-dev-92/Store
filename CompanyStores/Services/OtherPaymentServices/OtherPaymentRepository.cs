using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.OtherPaymentServices
{
    public class OtherPaymentRepository
    {
        private readonly DrugDbContext _drugDbContext;

        public OtherPaymentRepository(DrugDbContext drugDbContext)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateOtherPayment(OtherPayment otherPayment)
        {
            if (otherPayment == null)
            {
                throw new ArgumentNullException(nameof(otherPayment));
            }
            _drugDbContext.OtherPayments.Add(otherPayment);
        }

        public void DeletOtherPayment(OtherPayment otherPayment)
        {
            _drugDbContext.OtherPayments.Remove(otherPayment);
        }

        public async Task<IEnumerable<OtherPayment>> GetOtherPayment()
        {
            return await _drugDbContext.OtherPayments.ToListAsync();
        }

        public async Task<OtherPayment> GetOtherPaymentById(int Id)
        {

            return await _drugDbContext.OtherPayments.SingleOrDefaultAsync(o => o.OtherPaymentId == Id);
        }

        public async Task<bool> OtherPaymentExist(int Id)
        {
            return await _drugDbContext.OtherPayments.AnyAsync(o => o.OtherPaymentId == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public void UpdateOtherPayment(OtherPayment otherPayment, int Id)
        {

        }
    }
}
