using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class OfficeInvoice
    {
        public int OfficeInvoiceId { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public int BuyInvoiceId { get; set; }
        public BuyInvoice BuyInvoice { get; set; }
    }
}
