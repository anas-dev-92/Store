using System;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Helper;
using DrugStore.Model.AdminModel;
using DrugStore.Services.AdminsServices;
using DrugStore.Help;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace DrugStore.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminsRepository _adminRepo;
        private readonly ApSetting _appsettings;
        private readonly IMapper _mapper;

        public AdminController(IAdminsRepository adminRepository, IOptions<ApSetting> appSettings, IMapper mapper)
        {
            _adminRepo = adminRepository ?? throw new ArgumentNullException(nameof(adminRepository));
            _appsettings = appSettings.Value;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _adminRepo.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var admin = _mapper.Map<Admin>(model);

            try
            {
                // create user
                _adminRepo.Create(admin, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            // map model to entity and set id
            var admin = _mapper.Map<Admin>(model);
            admin.AdminId = id;

            try
            {
                // update user 
                _adminRepo.Update(admin, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [Helper.Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var admin = _adminRepo.GetAll();
            return Ok(admin);
        }
    }
}