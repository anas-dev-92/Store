using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class TransportInvoice
    {
        public int TransportInvoiceId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public CompanyStore CompanyStores { get; set; }
        public int CompanyStoreId { get; set; }
        public int Date { get; set; }
    }
}
