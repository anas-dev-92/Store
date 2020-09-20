using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.TransportInvoiceModel;
using DrugStore.Services.CompanyStoreervices;
using DrugStore.Services.TransportInvoiceServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/TransportInvoice")]
    [ApiController]
    public class TransportInvoiceController : ControllerBase
    {
        private readonly ICompanyStoreRepository _companyRepo;
            private readonly ITransportInvoiceRepository _TransportInvoiceRepo;
            private readonly IMapper _mapper;

        public TransportInvoiceController(ITransportInvoiceRepository transportInvoiceRepository, IMapper mapper, ICompanyStoreRepository company)
        {
            _TransportInvoiceRepo = transportInvoiceRepository ?? throw new ArgumentNullException(nameof(transportInvoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = company ?? throw new ArgumentNullException(nameof(company));
        }
        [HttpGet]
        public async Task<IActionResult> GetTransportInvoice()
            {
            //if (! _companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
                var tinvoice = await _TransportInvoiceRepo.GetTransportInvoice();
                return Ok(_mapper.Map<IEnumerable<TransportInvoiceForGet>>(tinvoice));
            }
            [HttpGet]
            [Route("{id}", Name = "TransportInvoice")]
            public async Task<IActionResult> GetTransportInvoiceById(int Id)
            {
            var tinvoice = await _TransportInvoiceRepo.GetTransportInvoiceById(Id);
                if (tinvoice == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<TransportInvoiceForGet>(tinvoice));
            }

            [HttpPost]
        public async Task<IActionResult> CreateTransportInvoice( [FromBody] TransportInvoiceForCreate transportInvoiceForCreate)
            {
            //if (! _companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var tinvoice = _mapper.Map<TransportInvoice>(transportInvoiceForCreate);
               _TransportInvoiceRepo.CreateTransportInvoice(tinvoice);
               await _TransportInvoiceRepo.SaveChanges();
               await _TransportInvoiceRepo.GetTransportInvoiceById( tinvoice.TransportInvoiceId);
               return CreatedAtRoute("TransportInvoice", new {  id = tinvoice.TransportInvoiceId }, tinvoice);
            }
        [HttpPatch]
            public async Task<IActionResult> UpdateTransportInvoice(int Id, [FromBody] JsonPatchDocument<TransportInvoiceForUpdate> jsonPatch)
            {
                var tinvoice = await _TransportInvoiceRepo.GetTransportInvoiceById(Id);
                if (tinvoice == null)
                {
                    return NotFound();
                }
                var Utinvoice = _mapper.Map<TransportInvoiceForUpdate>(tinvoice);
                jsonPatch.ApplyTo(Utinvoice, ModelState);
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                if (!TryValidateModel(Utinvoice))
                {
                    return BadRequest(ModelState);
                }
                _mapper.Map(Utinvoice, tinvoice);
                _TransportInvoiceRepo.UpdateTransportInvoice(tinvoice, Id);
                await _TransportInvoiceRepo.SaveChanges();
                return Ok();
            }
            [HttpDelete]
           // [HttpHead]//this one if you want to active the head request in you api
            public async Task<IActionResult> DeleteTransportInvoice(int Id)
            {
                var detinvoice = await _TransportInvoiceRepo.GetTransportInvoiceById(Id);
                if (detinvoice == null)
                {
                    return NotFound();
                }
                _TransportInvoiceRepo.DeleteTransportInvoice(detinvoice);
                await _TransportInvoiceRepo.SaveChanges();
                return Ok();
            }
     }
}
