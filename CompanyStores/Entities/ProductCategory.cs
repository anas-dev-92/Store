using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class ProductCategory
    {
        public Products Products { get; set; }
        public int ProductId { get; set; }
        public Categories Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
