using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.ProductReturnProfile
{
    public class ProductReturnProfile:Profile
    {
        public ProductReturnProfile()
        {
            CreateMap<Entities.ProductsReturn, Model.ProductReturnModel.ProductReturnForGet>();
            CreateMap<Model.ProductReturnModel.ProductReturnForCreate, Entities.ProductsReturn>();
            CreateMap<Entities.ProductsReturn, Model.ProductReturnModel.ProductReturnForUpdate>().ReverseMap();
        }
    }
}
