using AutoMapper;
using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyStores.Profiles.ProductCategoryProfile
{
    public class PCategoryProfile:Profile
    {
        public PCategoryProfile()
        {
            CreateMap<Models.ProductCategory.AddProductCategory,ProductAndCategory>();
        }
    }
}
