using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public int Roll { get; set; }
        public CompanyStore CompanyStores { get; set; }
        public int CompanyStoresId { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
       = new List<Invoice>();
        public ICollection<PaymentBill> PaymentBills { get; set; }
       = new List<PaymentBill>();
        public ICollection<TakeBill> TakeBills { get; set; }
        = new List<TakeBill>();
        public ICollection<OtherPayment> OtherPayments { get; set; }
       = new List<OtherPayment>();
        public ICollection<BuyInvoice> BuyInvoices { get; set; }
     = new List<BuyInvoice>();
    }
}
