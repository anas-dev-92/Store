using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.BuyInvoiceModel;
using DrugStore.Services.BuyInvoiceServices;
using DrugStore.Services.CompanyStoreervices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyInvoiceController : ControllerBase
    {
        private readonly IBuyInvoiceRepository _buyInvoiceRepository;
        private readonly IMapper _mapper;
        private readonly ICompanyStoreRepository _companyRepo;

        public BuyInvoiceController(IBuyInvoiceRepository buyInvoiceRepository, IMapper mapper, ICompanyStoreRepository companyRepo)
        {
            _buyInvoiceRepository = buyInvoiceRepository ?? throw new ArgumentNullException(nameof(buyInvoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = companyRepo ?? throw new ArgumentNullException(nameof(companyRepo));
        }
        [HttpGet]
        [Route("api/{companyId}/[controller]")]
        public async Task<IActionResult> GetBuyInvoice()
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var buyinvoice = await _buyInvoiceRepository.GetBuyInvoice();
            return Ok(_mapper.Map<IEnumerable<BuyInvoiceForGet>>(buyinvoice));
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetBuyInvoice")]
        public async Task<IActionResult> GetBuyInvoiceById(int Id)
        {
            var buyinvoice = await _buyInvoiceRepository.GetBuyInvoiceById(Id);
            if (buyinvoice == null)
            {
                return NotFound();
            }
            return Ok(buyinvoice);
        }
        [HttpPost(Name ="AddBuyInvoice")]
        [Route("api/{companyId}/[controller]")]
        public async Task<IActionResult> CreateBuyInvoice([FromBody] BuyInvoiceForCreate buyInvoiceForCreate)
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var buyinvoice = _mapper.Map<BuyInvoice>(buyInvoiceForCreate);
            _buyInvoiceRepository.CreateBuyInvoice(buyinvoice);
            await _buyInvoiceRepository.SaveChanges();
            await _buyInvoiceRepository.GetBuyInvoiceById(buyinvoice.BuyInvoiceId);
            return CreatedAtRoute("GetBuyInvoice", new { id = buyinvoice.BuyInvoiceId }, buyinvoice);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateBuyInvoice(int Id, [FromBody] JsonPatchDocument<BuyInvoiceForUpdate> jsonPatch)
        {
            if (!await _buyInvoiceRepository.BuyInvoiceExist(Id))
            {
                return NotFound();
            }
            var buyinvoice = await _buyInvoiceRepository.GetBuyInvoiceById(Id);
            if (buyinvoice == null)
            {
                return NotFound();
            }
            var Uinvoicee = _mapper.Map<BuyInvoiceForUpdate>(buyinvoice);
            jsonPatch.ApplyTo(Uinvoicee, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uinvoicee))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uinvoicee, buyinvoice);
            _buyInvoiceRepository.UpdateBuyInvoice(buyinvoice, Id);
            await _buyInvoiceRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBuyInvoice(int Id)
        {
            if (!await _buyInvoiceRepository.BuyInvoiceExist(Id))
            {
                return NotFound();
            }
            var deinvoice = await _buyInvoiceRepository.GetBuyInvoiceById(Id);
            if (deinvoice == null)
            {
                return NotFound();
            }
            _buyInvoiceRepository.DeleteBuyInvoice(deinvoice);
            await _buyInvoiceRepository.SaveChanges();
            return Ok();
        }
    }
}
