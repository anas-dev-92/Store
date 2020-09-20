using System;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.PaymentBillModel;
using DrugStore.Services.CompanyStoreervices;
using DrugStore.Services.PaymentBillServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentBillController : ControllerBase
    {
        private readonly IPaymentBillRepository _paymentBillRepo;
        private readonly IMapper _mapper;
        private readonly ICompanyStoreRepository _companyRepo;

        public PaymentBillController(IPaymentBillRepository paymentBillRepo, IMapper mapper, ICompanyStoreRepository companyRepo)
        {
            _paymentBillRepo = paymentBillRepo ?? throw new ArgumentNullException(nameof(paymentBillRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = companyRepo ?? throw new ArgumentNullException(nameof(companyRepo));
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentBill()
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var payment = await _paymentBillRepo.GetPaymentBill();
            return Ok(payment);
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetPaymentBill")]
        public async Task<IActionResult> GetPaymentBillById(int Id)
        {
            var payment = await _paymentBillRepo.GetPBillById(Id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePaymentBill([FromBody] PaymentBillForCreate paymentBillForCreate)
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var payment = _mapper.Map<PaymentBill>(paymentBillForCreate);
            _paymentBillRepo.CreatePaymentBill(payment);
            await _paymentBillRepo.SaveChanges();
            await _paymentBillRepo.GetPBillById(payment.PaymentBillId);
            return CreatedAtRoute("GetPaymentBill", new { id = payment.PaymentBillId }, payment);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdatePaymentBill(int Id, [FromBody] JsonPatchDocument<PaymentBillForUpdate> jsonPatch)
        {
            if (!await _paymentBillRepo.PBillExist(Id))
            {
                return NotFound();
            }
            var payment = await _paymentBillRepo.GetPBillById(Id);
            if (payment == null)
            {
                return NotFound();
            }
            var Upayment = _mapper.Map<PaymentBillForUpdate>(payment);
            jsonPatch.ApplyTo(Upayment, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Upayment))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Upayment, payment);
            _paymentBillRepo.UpdatePaymentBill(payment, Id);
            await _paymentBillRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePaymentBill(int Id)
        {
            if (!await _paymentBillRepo.PBillExist(Id))
            {
                return NotFound();
            }
            var depayment = await _paymentBillRepo.GetPBillById(Id);
            if (depayment == null)
            {
                return NotFound();
            }
            _paymentBillRepo.DeletePBill(depayment);
            await _paymentBillRepo.SaveChanges();
            return Ok();
        }
    }
}
