using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.PaymentBillProfile
{
    public class PaymentBillProfile:Profile
    {
        public PaymentBillProfile()
        {
            CreateMap<Entities.PaymentBill, Model.PaymentBillModel.PaymentBillForGet>();
            CreateMap<Model.PaymentBillModel.PaymentBillForCreate, Entities.PaymentBill>();
            CreateMap<Entities.PaymentBill, Model.PaymentBillModel.PaymentBillForUpdate>().ReverseMap();
        }
    }
}
