using System;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.OfficeModel;
using DrugStore.Services.CompanyStoreervices;
using DrugStore.Services.OfficeServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepo;
        private readonly IMapper _mapper;
        private readonly ICompanyStoreRepository _companyRepo;

        public OfficeController(IOfficeRepository officeRepo, IMapper mapper, ICompanyStoreRepository companyRepo)
        {
            _officeRepo = officeRepo ?? throw new ArgumentNullException(nameof(officeRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _companyRepo = companyRepo ?? throw new ArgumentNullException(nameof(companyRepo));
        }
        [HttpGet]
        [Route("api/{companyId}/Offices")]
        public async Task<IActionResult>GetOffice()
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var offices = await _officeRepo.GetOffice();
            return Ok(_mapper.Map<OfficeForGet>(offices));
        }
        [HttpGet]
        [Route("{id}", Name = "Office")]
        public async Task<IActionResult>GetOfficeById(int Id)
        {
            var office = await _officeRepo.GetOfficeById(Id);
            if (office ==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<OfficeForGet>(office));
        }
        [HttpPost]
        
        public async Task<IActionResult> CreateOffice([FromBody]OfficeForCreate officeForCreate)
        {
            //if (!_companyRepo.CompanyStoresExist(companyId))
            //{
            //    return NotFound();
            //}
            var officeEntity = _mapper.Map<Office>(officeForCreate);
            _officeRepo.CreateOffice(officeEntity);
            await _officeRepo.SaveChanges();
            var officeReturn = _mapper.Map<OfficeForGet>(officeEntity);
            return CreatedAtRoute("GetOffice",
                new { officeid = officeReturn.OfficeId },
                officeReturn);
        }
        [HttpPatch]
        public async Task<IActionResult>UpdateOffice(int Id, [FromBody]JsonPatchDocument<OfficeForUpdate> jsonPatch)
        {
            if (!await _officeRepo.OfficeExist(Id))
            {
                return NotFound();
            }
            var office = await _officeRepo.GetOfficeById(Id);
            if (office == null)
            {
                return NotFound();
            }
            var Uoffice = _mapper.Map<OfficeForUpdate>(office);
            jsonPatch.ApplyTo(Uoffice, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uoffice))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uoffice, office);
            _officeRepo.UpdateOffice(office, Id);
            await _officeRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOffice(int Id)
        {
            if (!await _officeRepo.OfficeExist(Id))
            {
                return NotFound();
            }
            var deoffice = await _officeRepo.GetOfficeById(Id);
            if (deoffice == null)
            {
                return NotFound();
            }
            _officeRepo.DeleteOffice(deoffice);
            await _officeRepo.SaveChanges();
            return Ok();
        }
    }
}