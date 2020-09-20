using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.InvoiceModel;
using DrugStore.Model.ProductModel;
using DrugStore.Services.InvoiceServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IinvoiceRepository _invoiceRepo;
        private readonly IMapper _mapper;

        public InvoiceController(IinvoiceRepository invoiceRepo, IMapper mapper)
        {
            _invoiceRepo = invoiceRepo ?? throw new ArgumentNullException(nameof(invoiceRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
         [HttpGet]
        public async Task<IActionResult> GetInvoice()
        {
            var invoice =await _invoiceRepo.GetInvoice();
            return Ok(_mapper.Map<IEnumerable<InvoiceForGet>>(invoice));
        }
        [HttpGet]
        [Route("{id}", Name = "GetInvoiceById")]
        public async Task<IActionResult> GetInvoiceById(int Id)
        {
            var invoice = await _invoiceRepo.GetInvoiceById(Id);
            if (invoice == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<InvoiceForGet>(invoice));
        }
        //[HttpGet]
        //[Route("{id}", Name = "GetInvoiceForCustomer")]
        //public async Task<IActionResult> GetInvoiceById(int InvoiceId,int CustomerId)
        //{
        //    if (!await _customerRepository.CustomerExistAsync(CustomerId))
        //    {
        //        return NotFound();
        //    }

        //    var invoice = await _invoiceRepo.GetInvoiceById(InvoiceId,invoiceId);
        //    if (invoice == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_mapper.Map<InvoiceForGet>(invoice));
        //}
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] InvoiceForCreate invoiceForCreate)
        {

            var invoiceEntity = _mapper.Map<Invoice>(invoiceForCreate);
            _invoiceRepo.CreateInvoice(invoiceEntity);
            await _invoiceRepo.SaveChanges();
            var invoiceReturn = _mapper.Map<InvoiceForGet>(invoiceEntity);
            //return CreatedAtRoute("GetInvoiceById",
            //    new { invoiceId = invoiceReturn.InvoiceId },
            //    invoiceReturn);
            return Ok(invoiceReturn.InvoiceId);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateInvoice(int InvoiceId, [FromBody] JsonPatchDocument<InvoiceForUpdate> jsonPatch)
        {
            var invoice = await _invoiceRepo.GetInvoiceById(InvoiceId);
            if (invoice == null)
            {
                return NotFound();
            }
            var Uinvoice = _mapper.Map<InvoiceForUpdate>(invoice);
            jsonPatch.ApplyTo(Uinvoice, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uinvoice))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uinvoice, invoice);
            _invoiceRepo.UpdateInvoice(invoice, InvoiceId);
            await _invoiceRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        //[HttpHead]this one if you want to active the head request in you api
        public async Task<IActionResult> DeleteInvoice(int Id)
        {
            var deinvoice = await _invoiceRepo.GetInvoiceById(Id);
            if (deinvoice == null)
            {
                return NotFound();
            }
            _invoiceRepo.DeleteInvoice(deinvoice);
            await _invoiceRepo.SaveChanges();
            return Ok();
        }
       
    }
}
