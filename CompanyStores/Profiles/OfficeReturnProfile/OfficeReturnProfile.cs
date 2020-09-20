using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.OfficeReturnProfile
{
    public class OfficeReturnProfile:Profile
    {
        public OfficeReturnProfile()
        {
            CreateMap<Entities.OfficeReturn, Model.OfficeReturnModel.OfficeReturnForGet>();
            CreateMap<Model.OfficeReturnModel.OfficeReturnForCreate, Entities.OfficeReturn>();
            CreateMap<Entities.OfficeReturn, Model.OfficeReturnModel.OfficeReturnForUpdate>().ReverseMap();
        }
    }
}
