using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class CompanyStore
    {

        public int CompanyStoresId { get; set; }
        public string StoreName { get; set; }
        public string StoreImage { get; set; }
        public ICollection<Admin> Admins { get; set; }
        = new List<Admin>();
        public ICollection<Products> Products { get; set; }
        = new List<Products>();
        public ICollection<Invoice> Invoices { get; set; }
        = new List<Invoice>();
        public ICollection<Categories> Categories { get; set; }
        = new List<Categories>();
        public ICollection<PaymentBill> PaymentBills { get; set; }
        = new List<PaymentBill>();
        public ICollection<TakeBill> TakeBills { get; set; }
        = new List<TakeBill>();
        public ICollection<Customer> Customers { get; set; }
        = new List<Customer>();
        public ICollection<BuyInvoice> BuyInvoices { get; set; }
    = new List<BuyInvoice>();
        public ICollection<Office> Offices { get; set; }
= new List<Office>();
        public ICollection<TransportInvoice> transportInvoices { get; set; }
= new List<TransportInvoice>();
    }
}
