using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.TransportInvoiceProfile
{
    public class TransportInvoiceProfile:Profile
    {
        public TransportInvoiceProfile()
        {
            CreateMap<Entities.TransportInvoice, Model.TransportInvoiceModel.TransportInvoiceForGet>();
            CreateMap<Model.TransportInvoiceModel.TransportInvoiceForCreate, Entities.TransportInvoice>();
            CreateMap<Entities.TransportInvoice, Model.TransportInvoiceModel.TransportInvoiceForUpdate>().ReverseMap();
        }
    }
}
