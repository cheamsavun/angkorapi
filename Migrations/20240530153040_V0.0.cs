using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AngkorAPI.Migrations
{
    /// <inheritdoc />
    public partial class V00 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "data");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NameLoc = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LongDescription = table.Column<string>(type: "text", maxLength: 2147483647, nullable: true),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TitleOfCurtesyId = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    GenderId = table.Column<int>(type: "integer", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCard = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IdCardIssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone1 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Phone2 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Fax = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AddressLine1 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Notes = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Expat = table.Column<bool>(type: "boolean", nullable: false),
                    Note = table.Column<string>(type: "text", maxLength: 2147483647, nullable: true),
                    EmployedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ProbationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_SysLists_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "system",
                        principalTable: "SysLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_SysLists_TitleOfCurtesyId",
                        column: x => x.TitleOfCurtesyId,
                        principalSchema: "system",
                        principalTable: "SysLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemType = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    CostingMethod = table.Column<int>(type: "integer", nullable: false),
                    ShowInCatalog = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NameLoc = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    LongDescription = table.Column<string>(type: "text", maxLength: 2147483647, nullable: true),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "data",
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    TitleOfCurtesyId = table.Column<int>(type: "integer", nullable: true),
                    FirstName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    LastName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    GenderId = table.Column<int>(type: "integer", nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IdCard = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IdCardIssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Phone1 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Phone2 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Fax = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AddressLine1 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AddressLine2 = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ContactName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Notes = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IsCorp = table.Column<bool>(type: "boolean", nullable: false),
                    IsLocal = table.Column<bool>(type: "boolean", nullable: false),
                    AccHandlerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Employees_AccHandlerId",
                        column: x => x.AccHandlerId,
                        principalSchema: "data",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_SysLists_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "system",
                        principalTable: "SysLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Customers_SysLists_TitleOfCurtesyId",
                        column: x => x.TitleOfCurtesyId,
                        principalSchema: "system",
                        principalTable: "SysLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocType = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DocDate = table.Column<DateOnly>(type: "date", nullable: false),
                    NextDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RefID = table.Column<int>(type: "integer", nullable: false),
                    RefType = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CustomerAddress = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    InvoiceNote = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    GrossAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    GrossAmountFc = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountValue = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountAmountFc = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalAmountFc = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxAmountFc = table.Column<decimal>(type: "numeric", nullable: false),
                    GrandTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    GrandTotalFc = table.Column<decimal>(type: "numeric", nullable: false),
                    Notes = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    TotalPaid = table.Column<decimal>(type: "numeric", nullable: false),
                    ShipToAddress = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    ShipViaId = table.Column<int>(type: "integer", nullable: true),
                    TrackingNumber = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CustomerNotes = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CommissionValue = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    CommissionAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    SysCreated = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "data",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "data",
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_SysLists_ShipViaId",
                        column: x => x.ShipViaId,
                        principalSchema: "system",
                        principalTable: "SysLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLines",
                schema: "data",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    ItemName = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountAmt = table.Column<decimal>(type: "numeric", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Remark = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: true),
                    OrderIndex = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "data",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Items_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "data",
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccHandlerId",
                schema: "data",
                table: "Customers",
                column: "AccHandlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GenderId",
                schema: "data",
                table: "Customers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TitleOfCurtesyId",
                schema: "data",
                table: "Customers",
                column: "TitleOfCurtesyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                schema: "data",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitleOfCurtesyId",
                schema: "data",
                table: "Employees",
                column: "TitleOfCurtesyId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_InvoiceId",
                schema: "data",
                table: "InvoiceLines",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLines_ItemId",
                schema: "data",
                table: "InvoiceLines",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                schema: "data",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DocType_Number",
                schema: "data",
                table: "Invoices",
                columns: new[] { "DocType", "Number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeId",
                schema: "data",
                table: "Invoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ShipViaId",
                schema: "data",
                table: "Invoices",
                column: "ShipViaId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                schema: "data",
                table: "Items",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLines",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Items",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "data");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "data");
        }
    }
}
