using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class ProductPrices
    {
        public int ProductPriceId { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
    }
}
