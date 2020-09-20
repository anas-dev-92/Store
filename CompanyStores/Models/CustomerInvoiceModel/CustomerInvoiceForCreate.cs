using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.CustomerInvoiceModel
{
    public class CustomerInvoiceForCreate
    {
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float TotalPrice { get; set; }
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNote { get; set; }
        public ICollection<Products> Product { get; set; }
 = new List<Products>();
    }
}
