using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class OfficeReturn
    {
        public int OfficeReturnId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public int BuyInvoiceId { get; set; }
        public BuyInvoice BuyInvoice { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }

    }
}
