using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyStores.Services.ProductCategory;
using DrugStore;
using DrugStore.Helper;
using DrugStore.Services.CategoryServices;
using DrugStore.Services.CompanyStoreervices;
using DrugStore.Services.CustomerServices;
using DrugStore.Services.InvoiceServices;
using DrugStore.Services.ProductServices;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CompanyStores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            //services.ConfigureLoggerService();
            services.AddControllers(stu =>
            {
                stu.ReturnHttpNotAcceptable = true;
            }).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>()).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
            services.Configure<ApSetting>(Configuration.GetSection("AppSettings"));
            //var appSettingsSection = _confgiguration.GetSection("AppSettings");
            //services.Configure<ApSetting>(appSettingsSection);
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DrugDbContext>(o =>
            {
                o.UseMySQL(connectionString);
            });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddTransient<ILogger, Logger<LoggingBroker>>();
            //services.AddTransient<ILoggingBroker, LoggingBroker>();
            //services.AddScoped<IAdminsRepository, AdminsRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IinvoiceRepository, InvoiceRepository>();
            //services.AddScoped<ITakeBillRepository, TakeBillRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICompanyStoreRepository, CompanyStoreRepository>();
            services.AddScoped<IProductCategory, ProductCategorysRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //this one is use when we need to get message if we get 500 because in Production nothing happen it show empty body
                app.UseExceptionHandler(apBuild =>
                {
                    apBuild.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An Unexepected Fault Happen , Try Again Later");
                    });
                });
            }
            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());



            //app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
