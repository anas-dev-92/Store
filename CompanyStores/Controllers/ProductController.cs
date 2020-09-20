using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Model.ProductModel;
using DrugStore.Services.CompanyStoreervices;
using DrugStore.Services.ProductServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly ICompanyStoreRepository _companyRepo;
        public ProductController(IProductRepository productRepository, IMapper mapper, DrugDbContext dbcontext, ICompanyStoreRepository companyRepo)
        {
            _productRepo = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = companyRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var products = await _productRepo.GetProduct();
            return Ok(_mapper.Map<IEnumerable<ProductForGet>>(products));
        }
        [HttpGet]
        [Route("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var products = await _productRepo.GetProductById(Id);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ProductForGet>(products));
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateProduct(int companyId,[FromBody] ProductForCreate productForCreate)
        //{
        //    if (!_companyRepo.CompanyStoresExist(companyId))
        //    {
        //        return NotFound();
        //    }
        //    var productEntity = _mapper.Map<Products>(productForCreate);
        //    _productRepo.CreateProduct(companyId,productEntity);
        //    await _productRepo.SaveChanges();
        //    var productReturn = _mapper.Map<ProductForGet>(productEntity);
        //    //return CreatedAtRoute("GetProduct",
        //    //    new { productId = productReturn.ProductId },
        //    //    productReturn);
        //    return Ok(productReturn);
        //}
        [HttpPatch]
        public async Task<IActionResult> UpdateProduct(int Id, [FromBody]JsonPatchDocument<ProductForUpdate> jsonPatch)
        {
            var products = await _productRepo.GetProductById(Id);
            if (products == null)
            {
                return NotFound();
            }
            var Uproduct = _mapper.Map<ProductForUpdate>(products);
            jsonPatch.ApplyTo(Uproduct, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uproduct))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uproduct, products);
            _productRepo.UpdateProduct(products, Id);
            await _productRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var deproduct = await _productRepo.GetProductById(Id);
            if (deproduct == null)
            {
                return NotFound();
            }
            _productRepo.DeleteProduct(deproduct);
            await _productRepo.SaveChanges();
            return Ok();
        }
    }
}