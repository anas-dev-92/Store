using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class ProductsReturn
    {
        public int ProductReturnId { get; set; }
        public DateTime PReturnDate { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public int CustomerInvoiceId { get; set; }
        public CustomerInvoice CustomerInvoice { get; set; }
    }
}
