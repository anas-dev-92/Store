using DrugStore.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.CustomerModel
{
    public class CustomerForGet
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string MarketName { get; set; }
        public float Debts { get; set; }
        public int CompanyStoresId { get; set; }
    }
}
