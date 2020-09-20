using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MarketName { get; set; }
        public float Debts { get; set; }
        public ICollection<TakeBill> TakeBills { get; set; }
       = new List<TakeBill>();
        public ICollection<Invoice> Invoices { get; set; }
       = new List<Invoice>();
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
    }
}
