using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.ProductModel
{
    public class ProductForCreate
    {

        public string ProductName { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Code { get; set; }
        public int CompanyStoresId { get; set; }

    }
}
