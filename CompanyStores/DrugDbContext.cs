using DrugStore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DrugStore
{
    public class DrugDbContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BuyInvoice> BuyInvoices { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeInvoice> OfficeInvoices { get; set; }
        public DbSet<OfficeReturn> OfficeReturns { get; set; }
        public DbSet<OtherPayment> OtherPayments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public DbSet<CompanyStore> CompanyStore { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductsReturn> ProductsReturns { get; set; }
        public DbSet<PaymentBill> PaymentBills { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<TakeBill> TakeBills { get; set; }
        public DbSet<TransportInvoice> transportInvoices { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DrugDbContext(DbContextOptions<DrugDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(sc => new { sc.ProductId, sc.CategoryId });
            modelBuilder.Entity<ProductCategory>()
             .HasOne<Products>(sc => sc.Products)
             .WithMany(s => s.ProductCategory)
             .HasForeignKey(sc => sc.ProductId);


            modelBuilder.Entity<ProductCategory>()
                .HasOne<Categories>(sc => sc.Categories)
                .WithMany(s => s.ProductCategory)
                .HasForeignKey(sc => sc.CategoryId);

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(a => a.AdminId);
                entity.Property(a => a.UserName).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(a => a.Password).HasColumnType("nvarchar(50)").IsRequired();
            });
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasOne(a => a.CompanyStores)
                .WithMany(c => c.Admins)
                .HasForeignKey(a => a.CompanyStoresId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<BuyInvoice>(entity =>
            {
                entity.HasKey(b => b.BuyInvoiceId);
                entity.Property(b => b.Date).IsRequired();
            });
            modelBuilder.Entity<BuyInvoice>(entity =>
            {
                entity.HasOne(b => b.Admin)
                       .WithMany(a => a.BuyInvoices)
                       .HasForeignKey(b => b.AdminId)
                       .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<BuyInvoice>(entity =>
            {
                entity.HasOne(b => b.CompanyStores)
                       .WithMany(c => c.BuyInvoices)
                       .HasForeignKey(b => b.CompanyStoreId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<TransportInvoice>(entity =>
            {
                entity.HasKey(ti => ti.TransportInvoiceId);
                entity.Property(ti => ti.Quantity).IsRequired();
                entity.Property(ti => ti.Date).IsRequired();
            });
            modelBuilder.Entity<TransportInvoice>(entity =>
            {
                entity.HasOne(ti => ti.Products)
                       .WithMany(p => p.transportInvoices)
                       .HasForeignKey(ti => ti.ProductId)
                       .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<TransportInvoice>(entity =>
            {
                entity.HasOne(ti => ti.CompanyStores)
                       .WithMany(cs => cs.transportInvoices)
                       .HasForeignKey(ti => ti.CompanyStoreId)
                       .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<ProductsReturn>(entity =>
            {
                entity.HasKey(pr => pr.ProductReturnId);
                entity.Property(pr => pr.PReturnDate).IsRequired();
            });
            modelBuilder.Entity<ProductsReturn>(entity =>
            {
                entity.HasOne(pr => pr.Products)
                       .WithMany(p => p.ProductsReturn)
                       .HasForeignKey(pr => pr.ProductId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<ProductsReturn>(entity =>
            {
                entity.HasOne(pr => pr.Invoice)
                       .WithMany(i => i.ProductsReturn)
                       .HasForeignKey(pr => pr.InvoiceId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<ProductsReturn>(entity =>
            {
                entity.HasOne(pr => pr.CustomerInvoice)
                       .WithMany(c => c.ProductsReturn)
                       .HasForeignKey(pr => pr.CustomerInvoiceId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                modelBuilder.Entity<CustomerInvoice>().HasKey(ci => new { ci.ProductId, ci.InvoiceId });
                entity.HasKey(c => c.CustomerInvoiceId);
                entity.Property(c => c.Quantity).IsRequired();
                entity.Property(c => c.TotalPrice).IsRequired();
            });
            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                entity.HasOne(c => c.Products)
                       .WithMany(p => p.CustomerInvoices)
                       .HasForeignKey(c => c.ProductId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<CustomerInvoice>(entity =>
            {
                entity.HasOne(c => c.Invoice)
                       .WithMany(i => i.CustomerInvoices)
                       .HasForeignKey(c => c.InvoiceId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<CompanyStore>(entity =>
            {
                entity.HasKey(cs => cs.CompanyStoresId);
                entity.Property(cs => cs.StoreName).IsRequired();
                entity.Property(cs => cs.StoreImage).IsRequired();
            });
            modelBuilder.Entity<PaymentBill>(entity =>
            {
                entity.HasKey(p => p.PaymentBillId);
                entity.Property(p => p.Amount).IsRequired();
                entity.Property(p => p.BillDate).IsRequired();
            });
            modelBuilder.Entity<PaymentBill>(entity =>
            {
                entity.HasOne(p => p.Admin)
                       .WithMany(a => a.PaymentBills)
                       .HasForeignKey(p => p.AdminId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<PaymentBill>(entity =>
            {
                entity.HasOne(p => p.CompanyStores)
                       .WithMany(cs => cs.PaymentBills)
                       .HasForeignKey(p => p.CompanyStoresId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<OfficeInvoice>(entity =>
            {
                entity.HasKey(o => o.OfficeInvoiceId);
                entity.Property(o => o.Quantity).IsRequired();
                entity.Property(o => o.TotalPrice).IsRequired();


            });
            modelBuilder.Entity<OfficeInvoice>(entity =>
            {
                entity.HasOne(o => o.Products)
                       .WithMany(p => p.OfficeInvoices)
                       .HasForeignKey(o => o.ProductsId)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<OfficeInvoice>(entity =>
            {
                entity.HasOne(o => o.BuyInvoice)
                       .WithMany(b => b.OfficeInvoices)
                       .HasForeignKey(o => o.BuyInvoiceId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<OtherPayment>(entity =>
            {
                entity.HasKey(o => o.OtherPaymentId);
                entity.Property(o => o.Amount).IsRequired();
                entity.Property(o => o.Date).IsRequired();

            });
            modelBuilder.Entity<OtherPayment>(entity =>
            {
                entity.HasOne(o => o.Admin)
                       .WithMany(a => a.OtherPayments)
                       .HasForeignKey(o => o.AdminId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(i => i.InvoiceId);
                entity.Property(i => i.InvoiceDate).IsRequired();
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(i => i.Customer)
                       .WithMany(c => c.Invoices)
                       .HasForeignKey(i => i.CustomerId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(i => i.CompanyStores)
                       .WithMany(cs => cs.Invoices)
                       .HasForeignKey(i => i.CompanyStoresId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(i => i.Admin)
                       .WithMany(a => a.Invoices)
                       .HasForeignKey(i => i.AdminId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<OfficeReturn>(entity =>
            {
                entity.HasKey(o => o.OfficeReturnId);
                entity.Property(o => o.Date).IsRequired();

            });
            modelBuilder.Entity<OfficeReturn>(entity =>
            {
                entity.HasOne(o => o.BuyInvoice)
                       .WithMany(b => b.OfficeReturns)
                       .HasForeignKey(o => o.BuyInvoiceId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<OfficeReturn>(entity =>
            {
                entity.HasOne(o => o.Products)
                       .WithMany(p => p.OfficeReturns)
                       .HasForeignKey(o => o.ProductsId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerName).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(c => c.Address).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(c => c.PhoneNumber).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(c => c.MarketName).HasColumnType("nvarchar(50)").IsRequired();

            });
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.MarketName);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasOne(c => c.CompanyStores)
                 .WithMany(cs => cs.Customers)
                 .HasForeignKey(c => c.CompanyStoresId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.NoAction);
            });
                modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(s => s.CategoryId);
                entity.Property(s => s.CategoryName).HasColumnType("nvarchar(150)").IsRequired();
            });
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasOne(ca => ca.CompanyStores)
                       .WithMany(cs => cs.Categories)
                       .HasForeignKey(ca => ca.CompanyStoresId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(m => m.ProductName).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(m => m.Company).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(m => m.Price).IsRequired();
                entity.Property(m => m.Quantity).IsRequired();
                entity.Property(m => m.Code).HasColumnType("varchar(500)");
            });
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasOne(p => p.CompanyStores)
                       .WithMany(cs => cs.Products)
                       .HasForeignKey(p => p.CompanyStoresId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            //modelBuilder.Entity<Products>(entity =>
            //{
            //    entity.HasMany(p => p.Categories)
            //            .WithMany(ca => ca.p)
            //            .IsRequired(false)
            //            .OnDelete(DeleteBehavior.NoAction);
            //});
            modelBuilder.Entity<TakeBill>(entity =>
            {
                entity.HasKey(t => t.TakeBillId);
                entity.Property(t => t.Amount).IsRequired();
                entity.Property(t => t.TBillDate).IsRequired();
                entity.Property(t => t.TBillNote).HasColumnType("varchar(1000)");
            });
            modelBuilder.Entity<TakeBill>(entity =>
            {
                entity.HasOne(t => t.CompanyStores)
                       .WithMany(cs => cs.TakeBills)
                       .HasForeignKey(t => t.CompanyStoresId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<TakeBill>(entity =>
            {
                entity.HasOne(t => t.Admin)
                       .WithMany(a => a.TakeBills)
                       .HasForeignKey(t => t.AdminId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<TakeBill>(entity =>
            {
                entity.HasOne(t => t.Customer)
                       .WithMany(c => c.TakeBills)
                       .HasForeignKey(t => t.CustomerId)
                       .IsRequired(false)
                       .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasKey(o => o.OfficeId);
                entity.Property(o => o.OfficeName).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(o => o.OfficePhone).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(o => o.OfficeAdress).HasColumnType("nvarchar(50)").IsRequired();
                entity.Property(o => o.OwnDebt).HasColumnName("OwnDebtForOffice");

            });
            modelBuilder.Entity<Office>(entity =>
            {
                entity.HasOne(o => o.CompanyStores)
                .WithMany(cs => cs.Offices)
                 .HasForeignKey(o => o.CompanyStoresId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
