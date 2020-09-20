using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CustomerServices
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DrugDbContext _drugDbcontext;

        public CustomerRepository(DrugDbContext drugDbContext)
        {
            _drugDbcontext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
        }
        public void CreateCustomer(Customer customer)
        {
            _drugDbcontext.Customers.Add(customer);
        }
        public async Task<bool> CustomerExistAsync(int Id)
        {
           return await _drugDbcontext.Customers.AnyAsync(c => c.CustomerId == Id);
        }

        public void DeleteCustomer(Customer customer)
        {
            _drugDbcontext.Remove(customer);
        }

        public async Task<Customer> GetCustomerByIdAsync(int Id)
        {
            return await _drugDbcontext.Customers.Where(c =>  c.CustomerId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _drugDbcontext.Customers.ToListAsync();
        }

        //public async Task<IEnumerable<Customer>> GetCustomersWithOthersAsync()
        //{
        //    return await _drugDbcontext.Customers.Include(b => b.TakeBills).Include(i => i.Invoices).ToListAsync();
        //}

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _drugDbcontext.SaveChangesAsync() > 0);
        }

        public void UpdateCustomer(Customer customer, int Id)
        {
            
        }
    }
}