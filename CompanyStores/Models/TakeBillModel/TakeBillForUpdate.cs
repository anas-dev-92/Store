using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.TakeBillModel
{
    public class TakeBillForUpdate
    {
        public float Amount { get; set; }
        public DateTime TBillDate { get; set; }
        public string TBillNote { get; set; }
    }
}
