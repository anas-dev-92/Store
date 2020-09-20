using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class PaymentBill
    {
        public int PaymentBillId { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public string Note { get; set; }
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
    }
}
