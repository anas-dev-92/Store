using System;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.OfficeReturnModel;
using DrugStore.Services.OfficeReturnServices;
using DrugStore.Services.ProductServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/Product/{productId}/OfficeReturn")]
    [ApiController]
    public class OfficeReturnController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IOfficeReturnRepository _oReturnRepo;
        private readonly IMapper _mapper;

        public OfficeReturnController(IOfficeReturnRepository oReturnRepo, IMapper mapper, IProductRepository productRepo)
        {
            _oReturnRepo = oReturnRepo ?? throw new ArgumentNullException(nameof(oReturnRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepo = productRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetOfficeReturn(int productId)
        {
            if (! await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oreturn = await _oReturnRepo.GetOfficeReturn(productId);
            return Ok(oreturn);
        }
        //[HttpGet(Name ="GetBookWithothers")]
        ////public async Task<IActionResult> GetCustomerWithOthers()
        ////{
        ////    var customers = await _customerRepo.GetCustomersWithOthersAsync();
        ////    return Ok(customers);
        ////}
        ///
        [HttpGet]
        [Route("{id}", Name = "GetOfficeReturn")]
        public async Task<IActionResult> GetMedicineReturnById(int productId,int Id)
        {
            if (! await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oreturn = await _oReturnRepo.GetOfficeReturnById(productId,Id);
            if (oreturn == null)
            {
                return NotFound();
            }
            return Ok(oreturn);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOfficeReturn(int productId,[FromBody] OfficeReturnForCreate officeReturnForCreate)
        {
            if (! await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oreturn = _mapper.Map<OfficeReturn>(officeReturnForCreate);
            _oReturnRepo.CreateOfficeReturn(productId,oreturn);
            await _oReturnRepo.SaveChanges();
            await _oReturnRepo.GetOfficeReturnById(productId,oreturn.OfficeReturnId);
            return CreatedAtRoute("GetOfficeReturn", new {productId, id = oreturn.OfficeReturnId }, oreturn);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateOfficeReturn(int productId,int Id, [FromBody] JsonPatchDocument<OfficeReturnForUpdate> jsonPatch)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var oreturn = await _oReturnRepo.GetOfficeReturnById(productId,Id);
            if (oreturn == null)
            {
                return NotFound();
            }
            var Uoreturn = _mapper.Map<OfficeReturnForUpdate>(oreturn);
            jsonPatch.ApplyTo(Uoreturn, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uoreturn))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uoreturn, oreturn);
            _oReturnRepo.UpdateOfficeReturn(oreturn, Id);
            await _oReturnRepo.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOfficeReturn(int productId,int Id)
        {
            if (!await _productRepo.ProductExist(productId))
            {
                return NotFound();
            }
            var deoreturn = await _oReturnRepo.GetOfficeReturnById(productId,Id);
            if (deoreturn == null)
            {
                return NotFound();
            }
            _oReturnRepo.DeleteOfficeReturn(deoreturn);
            await _oReturnRepo.SaveChanges();
            return Ok();
        }
    }
}
