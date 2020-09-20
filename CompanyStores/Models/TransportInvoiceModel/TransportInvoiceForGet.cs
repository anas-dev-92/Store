using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.TransportInvoiceModel
{
    public class TransportInvoiceForGet
    {
        public int TransportInvoiceId { get; set; }
        public int Quantity { get; set; }
        public int Date { get; set; }
    }
}
