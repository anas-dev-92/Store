using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class CustomerInvoice
    {
        public int CustomerInvoiceId { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public Products Products { get; set; }
        public ICollection<ProductsReturn> ProductsReturn { get; set; }
       = new List<ProductsReturn>();
    }
}
