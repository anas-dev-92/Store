using DrugStore.Entities;
using DrugStore.Model.AdminModel;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Help
{
    public class AdminModelValdation: AbstractValidator<AuthenticateRequest>
    {
        public AdminModelValdation(DrugDbContext drugDb)
        {
            RuleFor(a => a.UserName)
                                .MustAsync(async (value, x) =>
                                {
                                    return !(await drugDb.Customers.AnyAsync(c => c.MarketName == value));
                                }).WithMessage("The MarketName Already Exiest")
                .NotEmpty().WithMessage("UserName Can't be Empty")
                .Length(3, 50).WithMessage("UserName Must be More Than 3 Letter");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Password Can't be Empty");
        }
    }
}
