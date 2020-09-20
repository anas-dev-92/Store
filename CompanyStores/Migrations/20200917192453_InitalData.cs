using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CompanyStores.Migrations
{
    public partial class InitalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyStore",
                columns: table => new
                {
                    CompanyStoresId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StoreName = table.Column<string>(nullable: false),
                    StoreImage = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyStore", x => x.CompanyStoresId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Roll = table.Column<int>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admins_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categories_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MarketName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Debts = table.Column<float>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                });

            migrationBuilder.CreateTable(
                name: "Offices",
                columns: table => new
                {
                    OfficeId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OfficeName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OfficePhone = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OfficeAdress = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    OwnDebtForOffice = table.Column<float>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offices", x => x.OfficeId);
                    table.ForeignKey(
                        name: "FK_Offices_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    Code = table.Column<string>(type: "varchar(500)", nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    BuyPrice = table.Column<float>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                });

            migrationBuilder.CreateTable(
                name: "OtherPayments",
                columns: table => new
                {
                    OtherPaymentId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AdminId = table.Column<int>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherPayments", x => x.OtherPaymentId);
                    table.ForeignKey(
                        name: "FK_OtherPayments_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_OtherPayments_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentBills",
                columns: table => new
                {
                    PaymentBillId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    BillDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    AdminId = table.Column<int>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentBills", x => x.PaymentBillId);
                    table.ForeignKey(
                        name: "FK_PaymentBills_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_PaymentBills_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    InvoiceDate = table.Column<DateTime>(nullable: false),
                    InvoiceNote = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_Invoices_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "TakeBills",
                columns: table => new
                {
                    TakeBillId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    TBillDate = table.Column<DateTime>(nullable: false),
                    TBillNote = table.Column<string>(type: "varchar(1000)", nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    AdminId = table.Column<int>(nullable: false),
                    CompanyStoresId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeBills", x => x.TakeBillId);
                    table.ForeignKey(
                        name: "FK_TakeBills_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_TakeBills_CompanyStore_CompanyStoresId",
                        column: x => x.CompanyStoresId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                    table.ForeignKey(
                        name: "FK_TakeBills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "BuyInvoices",
                columns: table => new
                {
                    BuyInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Note = table.Column<string>(nullable: true),
                    OfficeId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    AdminId = table.Column<int>(nullable: false),
                    CompanyStoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyInvoices", x => x.BuyInvoiceId);
                    table.ForeignKey(
                        name: "FK_BuyInvoices_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_BuyInvoices_CompanyStore_CompanyStoreId",
                        column: x => x.CompanyStoreId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                    table.ForeignKey(
                        name: "FK_BuyInvoices_Offices_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Offices",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transportInvoices",
                columns: table => new
                {
                    TransportInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CompanyStoreId = table.Column<int>(nullable: false),
                    Date = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportInvoices", x => x.TransportInvoiceId);
                    table.ForeignKey(
                        name: "FK_transportInvoices_CompanyStore_CompanyStoreId",
                        column: x => x.CompanyStoreId,
                        principalTable: "CompanyStore",
                        principalColumn: "CompanyStoresId");
                    table.ForeignKey(
                        name: "FK_transportInvoices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoices",
                columns: table => new
                {
                    CustomerInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<float>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoices", x => x.CustomerInvoiceId);
                    table.ForeignKey(
                        name: "FK_CustomerInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_CustomerInvoices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "OfficeInvoices",
                columns: table => new
                {
                    OfficeInvoiceId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    Discount = table.Column<float>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    ProductsId = table.Column<int>(nullable: false),
                    BuyInvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeInvoices", x => x.OfficeInvoiceId);
                    table.ForeignKey(
                        name: "FK_OfficeInvoices_BuyInvoices_BuyInvoiceId",
                        column: x => x.BuyInvoiceId,
                        principalTable: "BuyInvoices",
                        principalColumn: "BuyInvoiceId");
                    table.ForeignKey(
                        name: "FK_OfficeInvoices_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "OfficeReturns",
                columns: table => new
                {
                    OfficeReturnId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    BuyInvoiceId = table.Column<int>(nullable: false),
                    ProductsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeReturns", x => x.OfficeReturnId);
                    table.ForeignKey(
                        name: "FK_OfficeReturns_BuyInvoices_BuyInvoiceId",
                        column: x => x.BuyInvoiceId,
                        principalTable: "BuyInvoices",
                        principalColumn: "BuyInvoiceId");
                    table.ForeignKey(
                        name: "FK_OfficeReturns_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductsReturns",
                columns: table => new
                {
                    ProductReturnId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PReturnDate = table.Column<DateTime>(nullable: false),
                    InvoiceId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CustomerInvoiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsReturns", x => x.ProductReturnId);
                    table.ForeignKey(
                        name: "FK_ProductsReturns_CustomerInvoices_CustomerInvoiceId",
                        column: x => x.CustomerInvoiceId,
                        principalTable: "CustomerInvoices",
                        principalColumn: "CustomerInvoiceId");
                    table.ForeignKey(
                        name: "FK_ProductsReturns_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceId");
                    table.ForeignKey(
                        name: "FK_ProductsReturns_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_CompanyStoresId",
                table: "Admins",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoices_AdminId",
                table: "BuyInvoices",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoices_CompanyStoreId",
                table: "BuyInvoices",
                column: "CompanyStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyInvoices_OfficeId",
                table: "BuyInvoices",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CompanyStoresId",
                table: "Categories",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_InvoiceId",
                table: "CustomerInvoices",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoices_ProductId",
                table: "CustomerInvoices",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyStoresId",
                table: "Customers",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MarketName",
                table: "Customers",
                column: "MarketName");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AdminId",
                table: "Invoices",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyStoresId",
                table: "Invoices",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeInvoices_BuyInvoiceId",
                table: "OfficeInvoices",
                column: "BuyInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeInvoices_ProductsId",
                table: "OfficeInvoices",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeReturns_BuyInvoiceId",
                table: "OfficeReturns",
                column: "BuyInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeReturns_ProductsId",
                table: "OfficeReturns",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Offices_CompanyStoresId",
                table: "Offices",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPayments_AdminId",
                table: "OtherPayments",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherPayments_CompanyStoresId",
                table: "OtherPayments",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentBills_AdminId",
                table: "PaymentBills",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentBills_CompanyStoresId",
                table: "PaymentBills",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyStoresId",
                table: "Products",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReturns_CustomerInvoiceId",
                table: "ProductsReturns",
                column: "CustomerInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReturns_InvoiceId",
                table: "ProductsReturns",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsReturns_ProductId",
                table: "ProductsReturns",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeBills_AdminId",
                table: "TakeBills",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeBills_CompanyStoresId",
                table: "TakeBills",
                column: "CompanyStoresId");

            migrationBuilder.CreateIndex(
                name: "IX_TakeBills_CustomerId",
                table: "TakeBills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_transportInvoices_CompanyStoreId",
                table: "transportInvoices",
                column: "CompanyStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_transportInvoices_ProductId",
                table: "transportInvoices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfficeInvoices");

            migrationBuilder.DropTable(
                name: "OfficeReturns");

            migrationBuilder.DropTable(
                name: "OtherPayments");

            migrationBuilder.DropTable(
                name: "PaymentBills");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductsReturns");

            migrationBuilder.DropTable(
                name: "TakeBills");

            migrationBuilder.DropTable(
                name: "transportInvoices");

            migrationBuilder.DropTable(
                name: "BuyInvoices");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CustomerInvoices");

            migrationBuilder.DropTable(
                name: "Offices");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "CompanyStore");
        }
    }
}
