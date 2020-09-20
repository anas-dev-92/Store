using DrugStore.Entities;
using DrugStore.Model.BuyInvoiceModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.FluentValidation
{
    public class BuyInvoiceModelValdation: AbstractValidator<BuyInvoiceForCreate>
    {
        public BuyInvoiceModelValdation()
        {
            RuleFor(b => b.Date).NotEmpty().WithMessage("Please Enter The Date Of Buy Invoice");
        }
    }
}
