using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.OtherPaymentModel;
using DrugStore.Services.OtherPaymentServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherPaymentController : ControllerBase
    {
        private readonly IOtherPaymentRepository _otherPaymentRepo;
        private readonly IMapper _mapper;

        public OtherPaymentController(IOtherPaymentRepository otherPaymentRepo, IMapper mapper)
        {
            _otherPaymentRepo = otherPaymentRepo ?? throw new ArgumentNullException(nameof(otherPaymentRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<IActionResult> GetOtherPayment()
        {
            var opayment = await _otherPaymentRepo.GetOtherPayment();
            return Ok(opayment);
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetOtherPayment")]
        public async Task<IActionResult> GetOtherPaymentById(int Id)
        {
            var payment = await _otherPaymentRepo.GetOtherPaymentById(Id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOtherPayment([FromBody] OtherPaymentForCreate otherPaymentForCreate)
        {
            var payment = _mapper.Map<OtherPayment>(otherPaymentForCreate);
            _otherPaymentRepo.CreateOtherPayment(payment);
            await _otherPaymentRepo.SaveChanges();
            await _otherPaymentRepo.GetOtherPaymentById(payment.OtherPaymentId);
            return CreatedAtRoute("GetOtherPayment", new { id = payment.OtherPaymentId }, payment);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOtherPayment(int Id, [FromBody] JsonPatchDocument<OtherPaymentForUpdate> jsonPatch)
        {
            if (!await _otherPaymentRepo.OtherPaymentExist(Id))
            {
                return NotFound();
            }
            var payment = await _otherPaymentRepo.GetOtherPaymentById(Id);
            if (payment == null)
            {
                return NotFound();
            }
            var Upayment = _mapper.Map<OtherPaymentForUpdate>(payment);
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
            _otherPaymentRepo.UpdateOtherPayment(payment, Id);
            await _otherPaymentRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOtherPayments(int Id)
        {
            if (!await _otherPaymentRepo.OtherPaymentExist(Id))
            {
                return NotFound();
            }
            var depayment = await _otherPaymentRepo.GetOtherPaymentById(Id);
            if (depayment == null)
            {
                return NotFound();
            }
            _otherPaymentRepo.DeleteOtherPayment(depayment);
            await _otherPaymentRepo.SaveChanges();
            return Ok();
        }
    }
}
