using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.OtherPaymentModel
{
    public class OtherPaymentForUpdate
    {
        public float Amount { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
