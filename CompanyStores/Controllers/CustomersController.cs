using System;
using System.Threading.Tasks;
using DrugStore.Services.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DrugStore.Model.CustomerModel;
using DrugStore.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using DrugStore.Services.CompanyStoreervices;

namespace DrugStore.Controller
{
    [ApiController]
    [Route("api/[Controller]")]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        private readonly ICompanyStoreRepository _companyRepo;
        public CustomersController(ICustomerRepository customerRepository, IMapper mapper, ICompanyStoreRepository companyRepo)
        {
            _customerRepo = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = companyRepo ?? throw new ArgumentNullException(nameof(companyRepo));
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<CustomerForGet>>> GetCustomer()
        {
            var customers = await _customerRepo.GetCustomersAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerForGet>>(customers));
        }
        [HttpGet]
        [Route("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomerById(int Id)
        {
            var customer =await _customerRepo.GetCustomerByIdAsync(Id);
            if (customer ==null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer( [FromBody]CustomerForCreate customerForCreate)
        {
            var customer = _mapper.Map<Customer>(customerForCreate);
            _customerRepo.CreateCustomer(customer);
            await _customerRepo.SaveChangesAsync();
            await _customerRepo.GetCustomerByIdAsync(customer.CustomerId);
            return CreatedAtRoute("GetCustomer", new {id = customer.CustomerId }, customer);
        }
        [HttpPatch]
        [Route("{CustomerId}")]
        public async Task<IActionResult> UpdateCustomer(int CustomerId, [FromBody] JsonPatchDocument<CustomerForUpdate> jsonPatch)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(CustomerId);
            if (customer == null)
            {
                return NotFound();
            }
            var Ucustomer = _mapper.Map<CustomerForUpdate>(customer);
            jsonPatch.ApplyTo(Ucustomer, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Ucustomer))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Ucustomer, customer);
            _customerRepo.UpdateCustomer(customer, CustomerId);
            await _customerRepo.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            if (!await _customerRepo.CustomerExistAsync(Id))
            {
                return NotFound();
            }
            var decustomer = await _customerRepo.GetCustomerByIdAsync(Id);
            if (decustomer == null)
            {
                return NotFound();
            }
            _customerRepo.DeleteCustomer(decustomer);
            await _customerRepo.SaveChangesAsync();
            return Ok();
        }
    }
}