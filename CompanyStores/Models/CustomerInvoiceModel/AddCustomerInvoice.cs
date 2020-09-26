using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyStores.Models.CustomerInvoiceModel
{
    public class AddCustomerInvoice
    {
        public ICollection<Product> products { get; set; }
         = new List<Product>();
        public DateTime InvoiceDate { get; set; } = DateTimeOffset.UtcNow;
        public string InvoiceNote { get; set; }
        public int CustomerId { get; set; }
        public int AdminId { get; set; }
        public int CompanyStoresId { get; set; }
    }
}
