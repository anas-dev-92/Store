using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.TakeBillModel;
using DrugStore.Services.CompanyStoreervices;
using DrugStore.Services.TakeBillServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TakeBillController : ControllerBase
    {
        private readonly ITakeBillRepository _billRepository;
        private readonly IMapper _mapper;
        private readonly ICompanyStoreRepository _companyRepo;

        public TakeBillController(ITakeBillRepository billRepository, IMapper mapper, ICompanyStoreRepository companyRepo)
        {
            _billRepository = billRepository ?? throw new ArgumentNullException(nameof(billRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = companyRepo ?? throw new ArgumentNullException(nameof(companyRepo));
        }

        [HttpGet]
        public async Task<IActionResult> GetTakeBill()
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var takebill = await _billRepository.GetTakeBill();
            return Ok(_mapper.Map<IEnumerable<TakeBillForGet>>(takebill));
        }
        [HttpGet]
        [Route("{id}", Name = "TakeBill")]
        public async Task<IActionResult> GetTakeBillById(int TakeBillId)
        {
            var takebill = await _billRepository.GetTakeBillById(TakeBillId);
            if (takebill == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TakeBillForGet>(takebill));
        }
        [HttpPost]
        public async Task<IActionResult> CreateTakeBill([FromBody] TakeBillForCreate takeBillForCreate)
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var takebillEntity = _mapper.Map<TakeBill>(takeBillForCreate);
            _billRepository.CreateTakeBill(takebillEntity);
            await _billRepository.SaveChanges();
            await _billRepository.GetTakeBillById(takebillEntity.TakeBillId);
            return Ok(takebillEntity);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateTakeBill(int TakeBillId, [FromBody] JsonPatchDocument<TakeBillForUpdate> jsonPatch)
        {
            var takebill = await _billRepository.GetTakeBillById(TakeBillId);
            if (takebill == null)
            {
                return NotFound();
            }
            var Utakebill = _mapper.Map<TakeBillForUpdate>(takebill);
            jsonPatch.ApplyTo(Utakebill, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Utakebill))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Utakebill, takebill);
            _billRepository.UpdateTakeBill(takebill, TakeBillId);
            await _billRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        //[HttpHead]this one if you want to active the head request in you api
        public async Task<IActionResult> DeleteTakeBill(int Id)
        {

            var detakebill = await _billRepository.GetTakeBillById(Id);
            if (detakebill == null)
            {
                return NotFound();
            }
            _billRepository.DeleteTakeBill(detakebill);
            await _billRepository.SaveChanges();
            return Ok();
        }
    }
}
