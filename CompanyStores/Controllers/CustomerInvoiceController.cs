using System;
using System.Threading.Tasks;
using AutoMapper;
using DrugStore.Entities;
using DrugStore.Model.CustomerInvoiceModel;
using DrugStore.Services.CustomerInvoiceServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrugStore.Controller
{
    [Route("api/CustomerInvoice")]
    [ApiController]
    public class CustomerInvoiceController : ControllerBase
    {
        private readonly ICustomerInvoiceRepository _cInvoiceRepository;
        private readonly IMapper _mapper;
        private readonly DrugDbContext _context;

        public CustomerInvoiceController(ICustomerInvoiceRepository cInvoiceRepository, IMapper mapper, DrugDbContext context)
        {
            _cInvoiceRepository = cInvoiceRepository ?? throw new ArgumentNullException(nameof(cInvoiceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerInvoice()
        {

            var cinvoice = await _cInvoiceRepository.GetCustomerInvoice();
            return Ok(cinvoice);
        }
        [HttpGet]
        [Route("{id}", Name = "GetCustomerInvoice")]
        public async Task<IActionResult> GetCustomerInvoiceById(int Id)
        {

            var cinvoice = await _cInvoiceRepository.GetCustomerInvoiceById(Id);
            if (cinvoice == null)
            {
                return NotFound();
            }
            return Ok(cinvoice);
        }
        [HttpPost]
        public IActionResult Create(CustomerInvoiceForCreate viewModel)
        {

            var invoice = new Invoice
            {
                InvoiceDate = viewModel.InvoiceDate,
                InvoiceNote = viewModel.InvoiceNote,
            };
            _context.Add(invoice);

            foreach (var item in Products)
            {
                _context.Add(new CustomerInvoice
                {
                    Invoice = invoice,
                    Products = item
                });
            }

            _context.SaveChanges();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomerInvoice([FromBody] CustomerInvoiceForCreate customerInvoiceForCreate)
        {

            var cinvoice = _mapper.Map<CustomerInvoice>(customerInvoiceForCreate);
            _cInvoiceRepository.CreateCustomerInvoice(cinvoice);
            await _cInvoiceRepository.SaveChanges();
            await _cInvoiceRepository.GetCustomerInvoiceById(cinvoice.CustomerInvoiceId);
            return CreatedAtRoute("GetCustomerInvoice", new { id = cinvoice.CustomerInvoiceId }, cinvoice);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateCustomerInvoice(int Id, [FromBody] JsonPatchDocument<CustomerInvoiceForUpdate> jsonPatch)
        {

            if (!await _cInvoiceRepository.CustomerInvoiceExist(Id))
            {
                return NotFound();
            }
            var cinvoice = await _cInvoiceRepository.GetCustomerInvoiceById(Id);
            if (cinvoice == null)
            {
                return NotFound();
            }
            var Uinvoice = _mapper.Map<CustomerInvoiceForUpdate>(cinvoice);
            jsonPatch.ApplyTo(Uinvoice, ModelState);
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (!TryValidateModel(Uinvoice))
            {
                return BadRequest(ModelState);
            }
            _mapper.Map(Uinvoice, cinvoice);
            _cInvoiceRepository.UpdateCustomerInvoice(cinvoice, Id);
            await _cInvoiceRepository.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerInvoice(int Id)
        {
            var deinvoice = await _cInvoiceRepository.GetCustomerInvoiceById(Id);
            if (deinvoice == null)
            {
                return NotFound();
            }
            _cInvoiceRepository.DeleteCustomerInvoice(deinvoice);
            await _cInvoiceRepository.SaveChanges();
            return Ok();
        }
    }
}
