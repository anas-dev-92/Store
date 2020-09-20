﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.OfficeModel
{
    public class OfficeForGet
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficeAdress { get; set; }
        public float OwnDebt { get; set; }
    }
}
