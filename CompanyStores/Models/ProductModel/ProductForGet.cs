using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.ProductModel
{
    public class ProductForGet
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
    }
}
