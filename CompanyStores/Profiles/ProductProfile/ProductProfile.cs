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
            CreateMap<Entities.Products, Model.ProductModel.ProductForGet>();
            CreateMap<Model.ProductModel.ProductForCreate, Entities.Products>();
            CreateMap<Entities.Products, Model.ProductModel.ProductForUpdate>().ReverseMap();
        }
    }
}
