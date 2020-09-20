using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.InvoiceModel
{
    public class InvoiceForGet
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNote { get; set; }
        public int CustomerId { get; set; }
    }
}
