using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public DateTimeOffset InvoiceDate { get; set; } = DateTimeOffset.UtcNow;
        public string InvoiceNote { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
        public virtual ICollection<CustomerInvoice> CustomerInvoices { get; set; }
         = new List<CustomerInvoice>();
        public ICollection<ProductsReturn> ProductsReturn { get; set; }
         = new List<ProductsReturn>();
    }
}
