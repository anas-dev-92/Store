using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeAdress { get; set; }
        public float OwnDebt { get; set; }
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
    }
}
