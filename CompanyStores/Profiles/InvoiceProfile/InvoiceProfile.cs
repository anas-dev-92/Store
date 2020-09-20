using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Profiles.InvoiceProfile
{
    public class InvoiceProfile:Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Entities.Invoice, Model.InvoiceModel.InvoiceForGet>();
            CreateMap<Model.InvoiceModel.InvoiceForCreate, Entities.Invoice>();
            CreateMap<Entities.Invoice, Model.InvoiceModel.InvoiceForUpdate>().ReverseMap();
        }
    }
}
