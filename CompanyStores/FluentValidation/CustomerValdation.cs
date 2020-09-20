using DrugStore.Model.CustomerModel;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.FluentValidation
{
    public class CustomerValdation:AbstractValidator<CustomerForCreate>
    {
        //public CustomerValdation(DrugDbContext dbx)
        //{
        //    RuleFor(c => c.CustomerName).NotEmpty();
        //    RuleFor(c => c.MarketName).MaximumLength(50)
        //        //here for make the marketname in customer unique in the client side and it's not work need to chick why
        //        .MustAsync(async(value,x)=>
        //        {
        //            return !(await dbx.Customers.AnyAsync(c => c.MarketName == value));
        //        }).WithMessage("The MarketName Already Exiest");
        //    //here to make valdation for chick if one of these two are empty so can get errer you need to fill both if you put one of them
        //    When(c => !string.IsNullOrEmpty(c.MarketName) || !string.IsNullOrEmpty(c.PhoneNumber),
        //        () =>
        //        {
        //            RuleFor(c => c.MarketName).NotEmpty().WithMessage("Cann't be Empty If the Name of Customer is Enter");
        //            RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("Cann't be Empty If the Name of Customer is Enter");
        //        });

        //}
    }
}
