using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.CategoryProfile
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Model.CategoryModel.CategoryForGet>();
            CreateMap<Model.CategoryModel.CategoryForCreate, Entities.Category>();
            CreateMap<Entities.Category, Model.CategoryModel.CategoryForUpdate>().ReverseMap();
        }
    }
}
