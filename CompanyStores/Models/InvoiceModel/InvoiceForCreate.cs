﻿using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.InvoiceModel
{
    public class InvoiceForCreate
    {
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNote { get; set; }
        public int AdminId { get; set; }
        public int CustomerId { get; set; }
        public int CompanyStoresId { get; set; }
        public ICollection<Products> Products { get; set; }
        = new List<Products>();

    }
}