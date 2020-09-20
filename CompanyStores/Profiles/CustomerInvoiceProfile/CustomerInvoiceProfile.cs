using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.CustomerInvoiceProfile
{
    public class CustomerInvoiceProfile:Profile
    {
        public CustomerInvoiceProfile()
        {
            CreateMap<Entities.CustomerInvoice, Model.CustomerInvoiceModel.CustomerInvoiceForGet>();
            CreateMap<Model.CustomerInvoiceModel.CustomerInvoiceForCreate, Entities.CustomerInvoice>();
            CreateMap<Entities.CustomerInvoice, Model.CustomerInvoiceModel.CustomerInvoiceForUpdate>().ReverseMap();
        }
    }
}
