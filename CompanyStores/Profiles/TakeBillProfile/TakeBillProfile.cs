using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.TakeBillProfile
{
    public class TakeBillProfile:Profile
    {
        public TakeBillProfile()
        {
            CreateMap<Entities.TakeBill, Model.TakeBillModel.TakeBillForGet>();
            CreateMap<Model.TakeBillModel.TakeBillForCreate, Entities.TakeBill>();
            CreateMap<Entities.TakeBill, Model.TakeBillModel.TakeBillForUpdate>().ReverseMap();
        }
    }
}
