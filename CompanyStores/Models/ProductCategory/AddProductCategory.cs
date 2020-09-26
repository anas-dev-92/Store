using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyStores.Models.ProductCategory
{
    public class AddProductCategory
    {

        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public string BarCode { get; set; }
        public int CompanyStoresId { get; set; }
        public int CategoryId { get; set; }
    }
}
