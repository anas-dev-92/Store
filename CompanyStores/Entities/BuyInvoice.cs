using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class BuyInvoice
    {
        public int BuyInvoiceId { get; set; }
        public string Note { get; set; }
        public Office Office { get; set; }
        public DateTime Date { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int CompanyStoreId { get; set; }
        public CompanyStore CompanyStores { get; set; }
        public ICollection<OfficeInvoice> OfficeInvoices { get; set; }
    = new List<OfficeInvoice>();
        public ICollection<OfficeReturn> OfficeReturns { get; set; }
    = new List<OfficeReturn>();
    }
}
