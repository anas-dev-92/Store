using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.OtherPaymentProfile
{
    public class OtherPaymentProfile:Profile
    {
        public OtherPaymentProfile()
        {
            CreateMap<Entities.OtherPayment, Model.OtherPaymentModel.OtherPaymentForGet>();
            CreateMap<Model.OtherPaymentModel.OtherPaymentForCreate, Entities.OtherPayment>();
            CreateMap<Entities.OtherPayment, Model.OtherPaymentModel.OtherPaymentForUpdate>().ReverseMap();
        }
    }
}
