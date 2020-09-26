using AutoMapper;
using CompanyStores.Entities;
using CompanyStores.Models.CustomerInvoiceModel;
using DrugStore.Entities;
using DrugStore.Model.InvoiceModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrugStore.Services.CustomerInvoiceServices
{
    public class CustomerInvoiceRepository:ICustomerInvoiceRepository
    {
        private readonly DrugDbContext _drugDbContext;
        private readonly IMapper _mapper;

        public CustomerInvoiceRepository(DrugDbContext drugDbContext, IMapper mapper)
        {
            _drugDbContext = drugDbContext ?? throw new ArgumentNullException(nameof(drugDbContext));
            _mapper = mapper;
        }
        public void CreateCustomerInvoice(CustomerInvoice customerInvoice)
        {
            _drugDbContext.CustomerInvoices.Add(customerInvoice);
        }

        public void DeleteCustomerInvoice(CustomerInvoice customerInvoice)
        {
            _drugDbContext.CustomerInvoices.Remove(customerInvoice);
        }

        public async Task<IEnumerable<CustomerInvoice>> GetCustomerInvoice()
        {
            return await _drugDbContext.CustomerInvoices.ToListAsync();
        }

        public async Task<CustomerInvoice> GetCustomerInvoiceById(int Id)
        {
            return await _drugDbContext.CustomerInvoices.Where(c => c.CustomerInvoiceId == Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await _drugDbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> CustomerInvoiceExist(int Id)
        {
            return await _drugDbContext.CustomerInvoices.AnyAsync(c => c.CustomerInvoiceId == Id);
        }

        public void UpdateCustomerInvoice(CustomerInvoice customerInvoice, int Id)
        {

        }
        public async Task<ServicesResponse<InvoiceForGet>> AddCustomerInvoice(AddCustomerInvoice addCustomerInvoice)
        {
            ServicesResponse<InvoiceForGet> servicesResponse = new ServicesResponse<InvoiceForGet>();
            try
            {
                //another way to git the list of the id in object 
                //List<int> list = new List<int>();
                //foreach (product item in Products)
                //{
                //    list.Add(product.Id);
                //}


                //if (invoice == null)
                //{
                //    servicesResponse.Success = false;
                //    servicesResponse.Message = "CategoryNotFound";
                //    return servicesResponse;
                //}

                //if i want to add new category with the product
                //Category category = new Category
                //{
                //    CategoryName = newProductCategory.CategoryName
                //};
                //drugDb.Categories.Add(category);
                Invoice invoice = new Invoice
                {
                    InvoiceNote = addCustomerInvoice.InvoiceNote,
                    AdminId = addCustomerInvoice.AdminId,
                    CustomerId = addCustomerInvoice.CustomerId,
                    CompanyStoresId = addCustomerInvoice.CompanyStoresId,
                    InvoiceDate = addCustomerInvoice.InvoiceDate.Date
                };

                var result= await _drugDbContext.Products.Select(p => p.ProductId).ToListAsync();
                


                CustomerInvoice customerInvoice = new CustomerInvoice
                {
                    Products = result,
                    Invoice = invoice
                };
                await _drugDbContext.CustomerInvoices.AddAsync(customerInvoice);
                await _drugDbContext.SaveChangesAsync();
                servicesResponse.Data = _mapper.Map<InvoiceForGet>(invoice);
            }
            catch (Exception ex)
            {
                servicesResponse.Success = false;
                servicesResponse.Message = ex.Message;
            }
            return servicesResponse;
        }
    }
}
