using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.ProductProfile
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Model.ProductModel.ProductForGet>();
            CreateMap<Model.ProductModel.ProductForCreate, Entities.Product>();
            CreateMap<Entities.Product, Model.ProductModel.ProductForUpdate>().ReverseMap();
        }
    }
}
