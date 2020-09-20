using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.BuyInvoiceProfile
{
    public class BuyInvoiceProfile:Profile
    {
        public BuyInvoiceProfile()
        {
            CreateMap<Entities.BuyInvoice, Model.BuyInvoiceModel.BuyInvoiceForGet>();
            CreateMap<Model.BuyInvoiceModel.BuyInvoiceForCreate, Entities.BuyInvoice>();
            CreateMap<Entities.BuyInvoice, Model.BuyInvoiceModel.BuyInvoiceForUpdate>().ReverseMap();
        }
    }
}
