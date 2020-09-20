using DrugStore.Model.ProductModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.FluentValidation
{
    public class ProductValidation : AbstractValidator<ProductForCreate>
    {
        public ProductValidation()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Please Enter the Product Name").WithName("Product Name");
            RuleFor(p => p.Company).NotEmpty().WithMessage("Please Enter the Product Company");
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Quantity).NotEmpty();
            When(p => !string.IsNullOrEmpty(p.Company) || !string.IsNullOrEmpty(p.ProductName),
    () =>
    {
        RuleFor(p => p.Company).NotEmpty().WithMessage("Cann't be Empty If the Name of ProductName is Enter");
        RuleFor(p => p.ProductName).NotEmpty().WithMessage("Cann't be Empty If the Name of ProductName is Enter");
    });
        }
    }
}
