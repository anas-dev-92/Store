using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.CompanyStoreModel;
using DrugStore.Services.CompanyStoreervices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CompanyStoresController : ControllerBase
    {
        private readonly ICompanyStoreRepository _companyStoreRepository;
        private readonly IMapper _mapper;

        public CompanyStoresController(ICompanyStoreRepository companyStoreRepository, IMapper mapper)
        {
            _companyStoreRepository = companyStoreRepository ?? throw new ArgumentNullException(nameof(companyStoreRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<IActionResult> GetCompanyStores()
        {
            var cstore =await _companyStoreRepository.GetCompanyStore();
            return Ok(_mapper.Map<IEnumerable<CompanyStoreForGet>>(cstore));
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetCompanyStores")]
        public  IActionResult GetCompanyStoresById(int Id)
        {
            var cstore =  _companyStoreRepository.GetCompanyStoreById(Id);
            if (cstore == null)
            {
                return NotFound();
            }
            return Ok(cstore);
        }
        [HttpPost]
        public  IActionResult CreateCompanyStores([FromBody] CompanyStoreForCreate companyStoreForCreate)
        {
            var cstore = _mapper.Map<CompanyStore>(companyStoreForCreate);
            _companyStoreRepository.CreateCompanyStore(cstore);
             _companyStoreRepository.SaveChanges();
             _companyStoreRepository.GetCompanyStoreById(cstore.CompanyStoresId);
            return CreatedAtRoute("GetCompanyStores", new { id = cstore.CompanyStoresId }, cstore);
        }
        [HttpPatch]
        [Route("{id:int}")]
        public  IActionResult UpdateCompanyStores(int Id, [FromBody] JsonPatchDocument<CompanyStoreForUpdate> jsonPatch)
        {
            if (! _companyStoreRepository.CompanyStoreExist(Id))
            {
                return NotFound();
            }
            var cstore =  _companyStoreRepository.GetCompanyStoreById(Id);
            if (cstore == null)
            {
                return NotFound();
            }
            var Ucstore = _mapper.Map<CompanyStoreForUpdate>(cstore);
            jsonPatch.ApplyTo(Ucstore, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Ucstore))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Ucstore, cstore);
            _companyStoreRepository.UpdateCompanyStore(cstore, Id);
             _companyStoreRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public  IActionResult DeleteCompanyStores(int Id)
        {
            if (! _companyStoreRepository.CompanyStoreExist(Id))
            {
                return NotFound();
            }
            var destore =  _companyStoreRepository.GetCompanyStoreById(Id);
            if (destore == null)
            {
                return NotFound();
            }
            _companyStoreRepository.DeleteCompanyStore(destore);
             _companyStoreRepository.SaveChanges();
            return Ok();
        }
    }
}
