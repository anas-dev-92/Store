using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.CategoryModel;
using DrugStore.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _category;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository category, IMapper mapper)
        {
            _category = category ?? throw new ArgumentNullException(nameof(category));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _category.GetCategory();
            return Ok(_mapper.Map<CategoryForGet>(categories));
        }
        [HttpGet]
        [Route("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var categories = await _category.GetCategoryById(Id);
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryForGet>(categories));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreate categoryForCreate)
        {
            var categoryEntity = _mapper.Map<Categories>(categoryForCreate);
            _category.CreateCategory(categoryEntity);
            await _category.SaveChanges();
            var categoryReturn = _mapper.Map<CategoryForGet>(categoryEntity);
            return CreatedAtRoute("GetCategory",
                new { categoryId = categoryReturn.CategoryId },
                categoryReturn);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateCategory(int Id, [FromBody] JsonPatchDocument<CategoryForUpdate> jsonPatch)
        {
            if (!await _category.CategoryExist(Id))
            {
                return NotFound();
            }
            var categories = await _category.GetCategoryById(Id);
            if (categories == null)
            {
                return NotFound();
            }
            var Ucategory = _mapper.Map<CategoryForUpdate>(categories);
            jsonPatch.ApplyTo(Ucategory, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Ucategory))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Ucategory, categories);
            _category.UpdateCategory(categories, Id);
            await _category.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        [HttpHead]//this one if you want to active the head request in you api
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            if (!await _category.CategoryExist(Id))
            {
                return NotFound();
            }
            var decategory = await _category.GetCategoryById(Id);
            if (decategory == null)
            {
                return NotFound();
            }
            _category.DeleteCategory(decategory);
            await _category.SaveChanges();
            return Ok();
        }
    }
}
