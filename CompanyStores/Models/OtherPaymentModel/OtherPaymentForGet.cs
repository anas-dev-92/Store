using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.OtherPaymentModel
{
    public class OtherPaymentForGet
    {
        public int OtherPaymentId { get; set; }
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
