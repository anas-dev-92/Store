using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.PaymentBillModel
{
    public class PaymentBillForCreate
    {
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public string Note { get; set; }
    }
}
