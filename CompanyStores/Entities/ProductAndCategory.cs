using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class ProductAndCategory
    {
        public Product Products { get; set; }
        public int ProductId { get; set; }
        public Category Categories { get; set; }
        public int CategoryId { get; set; }
    }
}
