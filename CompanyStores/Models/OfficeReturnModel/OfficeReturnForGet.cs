using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.OfficeReturnModel
{
    public class OfficeReturnForGet
    {
        public int OfficeReturnId { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
