using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrugStore.Entities
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public string Code { get; set; }
        public string BarCode { get; set; }
        public float BuyPrice { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
= new List<ProductCategory>();
        public ICollection<TransportInvoice> transportInvoices { get; set; }
= new List<TransportInvoice>();
        public ICollection<CustomerInvoice> CustomerInvoices { get; set; }
       = new List<CustomerInvoice>();
        public ICollection<ProductsReturn> ProductsReturn { get; set; }
      = new List<ProductsReturn>();
        public int CompanyStoresId { get; set; }
        public CompanyStore CompanyStores { get; set; }
        public ICollection<OfficeInvoice> OfficeInvoices { get; set; }
   = new List<OfficeInvoice>();
        public ICollection<OfficeReturn> OfficeReturns { get; set; }
    = new List<OfficeReturn>();
    }
}
