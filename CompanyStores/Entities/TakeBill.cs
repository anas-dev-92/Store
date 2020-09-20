using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class TakeBill
    {
        public int TakeBillId { get; set; }
        public float Amount { get; set; }
        public DateTime TBillDate { get; set; }
        public string TBillNote { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
    }
}
