using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CustomerServices
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int Id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer, int Id);
        void DeleteCustomer(Customer customer);
        Task <bool> CustomerExistAsync(int Id);
        Task<bool> SaveChangesAsync();
        //Task<IEnumerable<Customer>> GetCustomersWithOthersAsync();
    }
}
