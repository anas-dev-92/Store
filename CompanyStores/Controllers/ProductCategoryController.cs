using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyStores.Models.ProductCategory;
using CompanyStores.Services.ProductCategory;
using DrugStore.Controller;
using DrugStore.Entities;
using DrugStore.Model.CategoryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.Mozilla;

namespace CompanyStores.Controllers
{
    [Route("api/ProductCategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategory _productCategory;
        private readonly IMapper _mapper;

        public ProductCategoryController(IProductCategory productCategory,IMapper mapper)
        {
            _productCategory = productCategory;
            _mapper = mapper;
        }
        //[HttpPost]
        //public async Task<IActionResult> AddProductCategory(AddProductCategory productCategory)
        //{
        //    return Ok(await _productCategory.AddProductCategory(productCategory));
        //}
        //[HttpPost]
        //public IActionResult CreateCategorys([FromBody]Category category)
        //{
        //    return Ok(_productCategory.CreateProductCategory(category));
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreateProductCategory([FromBody]AddProductCategory addProductCategory)
        //{
        //    var result = _mapper.Map<ProductAndCategory>(addProductCategory);
        //    _productCategory.CreateProductCategory(addProductCategory);
        //    await _productCategory.SaveChanges();
        //    return Ok(addProductCategory);
        //}
    }
}
