using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.ProductReturnModel;
using DrugStore.Services.ProductReturnServices;
using DrugStore.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReturnController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IProductReturnRepository _pReturnRepo;
        private readonly IMapper _mapper;

        public ProductReturnController(IProductReturnRepository pReturnRepo, IMapper mapper, IProductRepository productRepo)
        {
            _pReturnRepo = pReturnRepo ?? throw new ArgumentNullException(nameof(pReturnRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductReturn(int productId)
        {
            if (! await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var preturn = await _pReturnRepo.GetProductReturn( productId);
            return Ok(preturn);
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetProductReturn")]
        public async Task<IActionResult> GetProductReturnById(int productId,int Id)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var preturn = await _pReturnRepo.GetProductReturnById(productId, Id);
            if (preturn == null)
            {
                return NotFound();
            }
            return Ok(preturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductReturn(int productId,[FromBody] ProductReturnForCreate productReturnForCreate)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var preturn = _mapper.Map<ProductsReturn>(productReturnForCreate);
            _pReturnRepo.CreateProductReturn(productId,preturn);
            await _pReturnRepo.SaveChanges();
            await _pReturnRepo.GetProductReturnById(productId,preturn.ProductReturnId);
            return CreatedAtRoute("GetProductReturn", new { productId, id = preturn.ProductReturnId }, preturn);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateProductReturn(int productId,int Id, [FromBody] JsonPatchDocument<ProductReturnForUpdate> jsonPatch)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            if (!await _pReturnRepo.ProductReturnExist(Id))
            {
                return NotFound();
            }
            var preturn = await _pReturnRepo.GetProductReturnById(productId,Id);
            if (preturn == null)
            {
                return NotFound();
            }
            var Upreturn = _mapper.Map<ProductReturnForUpdate>(preturn);
            jsonPatch.ApplyTo(Upreturn, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Upreturn))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Upreturn, preturn);
            _pReturnRepo.UpdateProductReturn(preturn, Id);
            await _pReturnRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductReturn(int productId,int Id)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var depreturn = await _pReturnRepo.GetProductReturnById(productId,Id);
            if (depreturn == null)
            {
                return NotFound();
            }
            _pReturnRepo.DeleteProductReturn(depreturn);
            await _pReturnRepo.SaveChanges();
            return Ok();
        }
    }
}
