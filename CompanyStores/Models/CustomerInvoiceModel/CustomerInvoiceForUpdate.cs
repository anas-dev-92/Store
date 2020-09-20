using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.CustomerInvoiceModel
{
    public class CustomerInvoiceForUpdate
    {
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
    }
}
