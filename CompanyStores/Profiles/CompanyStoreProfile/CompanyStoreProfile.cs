using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.CompanyStoreProfile
{
    public class CompanyStoreProfile:Profile
    {
        public CompanyStoreProfile()
        {
            CreateMap<Entities.CompanyStore, Model.CompanyStoreModel.CompanyStoreForGet>();
            CreateMap<Model.CompanyStoreModel.CompanyStoreForCreate, Entities.CompanyStore>();
            CreateMap<Entities.CompanyStore, Model.CompanyStoreModel.CompanyStoreForUpdate>().ReverseMap();
        }
    }
}
