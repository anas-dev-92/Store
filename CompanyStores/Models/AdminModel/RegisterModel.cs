﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Model.AdminModel
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Roll { get; set; }
        public int CompanyStoresId { get; set; }
    }
}
