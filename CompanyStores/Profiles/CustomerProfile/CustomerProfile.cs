using AutoMapper;
using DrugStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.CustomerProfile
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Entities.Customer, Model.CustomerModel.CustomerForGet>();
            CreateMap<Model.CustomerModel.CustomerForCreate, Entities.Customer>();
            CreateMap<Entities.Customer, Model.CustomerModel.CustomerForUpdate>().ReverseMap();
        }
        
    }
}
