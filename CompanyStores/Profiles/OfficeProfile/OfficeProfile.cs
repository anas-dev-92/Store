using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.OfficeProfile
{
    public class OfficeProfile:Profile
    {
        public OfficeProfile()
        {
            CreateMap<Entities.Office, Model.OfficeModel.OfficeForGet>();
            CreateMap<Model.OfficeModel.OfficeForCreate, Entities.Office>();
            CreateMap<Entities.Office, Model.OfficeModel.OfficeForUpdate>().ReverseMap();
        }
    }
}
