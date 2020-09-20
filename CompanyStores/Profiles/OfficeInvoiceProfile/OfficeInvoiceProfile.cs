using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.OfficeInvoiceProfile
{
    public class OfficeInvoiceProfile:Profile
    {
        public OfficeInvoiceProfile()
        {
            CreateMap<Entities.OfficeInvoice, Model.OfficeInvoiceModel.OfficeInvoiceForGet>();
            CreateMap<Model.OfficeInvoiceModel.OfficeInvoiceForCreate, Entities.OfficeInvoice>();
            CreateMap<Entities.OfficeInvoice, Model.OfficeInvoiceModel.OfficeInvoiceForUpdate>().ReverseMap();
        }
    }
}
