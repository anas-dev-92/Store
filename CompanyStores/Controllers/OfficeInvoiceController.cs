using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.OfficeInvoiceModel;
using DrugStore.Services.OfficeInvoiceServices;
using DrugStore.Services.ProductServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/Product/{productId}/OfficeInovice")]
    [ApiController]
    public class OfficeInvoiceController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IOfficeInvoiceRepository _OInvoiceRepository;
        private readonly IMapper _mapper;

        public OfficeInvoiceController(IOfficeInvoiceRepository OInvoiceRepository, IMapper mapper, IProductRepository productRepo)
        {
            _OInvoiceRepository = OInvoiceRepository ?? throw new ArgumentNullException(nameof(OInvoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetOfficeInvoice(int productId)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oinvoice = await _OInvoiceRepository.GetOfficeInvoice(productId);
            return Ok(oinvoice);
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetOfficeInvoice")]
        public async Task<IActionResult> GetOfficeInvoiceById(int productId,int Id)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oinvoice = await _OInvoiceRepository.GetOfficeInvoiceById(productId,Id);
            if (oinvoice == null)
            {
                return NotFound();
            }
            return Ok(oinvoice);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfficeInvoice(int productId,[FromBody] OfficeInvoiceForCreate officeInvoiceForCreate)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oinvoice = _mapper.Map<OfficeInvoice>(officeInvoiceForCreate);
            _OInvoiceRepository.CreateOfficeInvoice(productId,oinvoice);
            await _OInvoiceRepository.SaveChanges();
            await _OInvoiceRepository.GetOfficeInvoiceById(productId,oinvoice.OfficeInvoiceId);
            return CreatedAtRoute("GetOfficeInvoice", new { productId,id = oinvoice.OfficeInvoiceId }, oinvoice);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOfficeInvoice(int productId,int Id, [FromBody] JsonPatchDocument<OfficeInvoiceForUpdate> jsonPatch)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            if (!await _OInvoiceRepository.OfficeInvoiceExist(Id))
            {
                return NotFound();
            }
            var oinvoice = await _OInvoiceRepository.GetOfficeInvoiceById(productId,Id);
            if (oinvoice == null)
            {
                return NotFound();
            }
            var Uinvoice = _mapper.Map<OfficeInvoiceForUpdate>(oinvoice);
            jsonPatch.ApplyTo(Uinvoice, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uinvoice))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uinvoice, oinvoice);
            _OInvoiceRepository.UpdateOfficeInvoice(oinvoice, Id);
            await _OInvoiceRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOfficeInvoice(int productId,int Id)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var deinvoice = await _OInvoiceRepository.GetOfficeInvoiceById(productId,Id);
            if (deinvoice == null)
            {
                return NotFound();
            }
            _OInvoiceRepository.DeleteOfficeInvoice(deinvoice);
            await _OInvoiceRepository.SaveChanges();
            return Ok();
        }
    }
}
