using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
       = new List<ProductCategory>();
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
    }
}
