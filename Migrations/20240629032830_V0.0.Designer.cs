﻿// <auto-generated />
using System;
using AngkorAPI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AngkorAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240629032830_V0.0")]
    partial class V00
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("data")
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AngkorAPI.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("NameLoc")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PhotoThumnail")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories", "data");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("ErrMsg")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Fax")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("FirstNameLoc")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("integer");

                    b.Property<string>("IdCard")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<DateOnly>("IdCardIssueDate")
                        .HasColumnType("date");

                    b.Property<int?>("IndustryId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCorp")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsLocal")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("LastNameLoc")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("NameLoc")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int?>("NationalityId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Phone1")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Phone2")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PhotoTh")
                        .HasColumnType("bytea");

                    b.Property<int?>("TitleOfCurtesyId")
                        .HasColumnType("integer");

                    b.Property<string>("VATIN")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("NationalityId");

                    b.HasIndex("TitleOfCurtesyId");

                    b.ToTable("Customers", "data");
                });

            modelBuilder.Entity("AngkorAPI.Entities.CustomerContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Note")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone1")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Phone2")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerContacts", "data");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerAddress")
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("CustomerNotes")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<decimal>("DiscountAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DiscountAmountFc")
                        .HasColumnType("numeric");

                    b.Property<string>("DiscountValue")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateOnly>("DocDate")
                        .HasColumnType("date");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GrandTotalFc")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GrossAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("GrossAmountFc")
                        .HasColumnType("numeric");

                    b.Property<string>("InvoiceNote")
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<DateOnly>("NextDate")
                        .HasColumnType("date");

                    b.Property<string>("Notes")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<int>("RefID")
                        .HasColumnType("integer");

                    b.Property<string>("RefType")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("ShipToAddress")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int?>("ShipViaId")
                        .HasColumnType("integer");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<decimal>("TaxAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TaxAmountFc")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalAmountFc")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TotalPaid")
                        .HasColumnType("numeric");

                    b.Property<string>("TrackingNumber")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<decimal>("XRate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("Number")
                        .IsUnique();

                    b.HasIndex("ShipViaId");

                    b.ToTable("Invoices", "data");
                });

            modelBuilder.Entity("AngkorAPI.Entities.InvoiceLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscountAmt")
                        .HasColumnType("numeric");

                    b.Property<decimal>("DiscountRate")
                        .HasColumnType("numeric");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("ItemName")
                        .HasMaxLength(800)
                        .HasColumnType("character varying(800)");

                    b.Property<short>("OrderIndex")
                        .HasColumnType("smallint");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<string>("Remark")
                        .HasMaxLength(4000)
                        .HasColumnType("character varying(4000)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TaxRate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ItemId");

                    b.ToTable("InvoiceLines", "data");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("ItemType")
                        .HasColumnType("integer");

                    b.Property<string>("LongDescription")
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<string>("NameLoc")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<bool>("ShowInCatalog")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items", "data");
                });

            modelBuilder.Entity("Angkorsoft.Core.Entities.SysArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("NameKh")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("PostalCode")
                        .HasColumnType("integer");

                    b.Property<int?>("SysAreaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SysAreaId");

                    b.ToTable("SysAreas", "system", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Angkorsoft.Core.Entities.SysList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Flags")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<short>("ListId")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SysLists", "system", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("Angkorsoft.Core.Entities.SysListHeader", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<short>("ParentId")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("SysListHeaders", "system", t =>
                        {
                            t.ExcludeFromMigrations();
                        });
                });

            modelBuilder.Entity("AngkorAPI.Entities.Category", b =>
                {
                    b.HasOne("AngkorAPI.Entities.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Customer", b =>
                {
                    b.HasOne("Angkorsoft.Core.Entities.SysList", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("Angkorsoft.Core.Entities.SysList", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("Angkorsoft.Core.Entities.SysList", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId");

                    b.HasOne("Angkorsoft.Core.Entities.SysList", "TitleOfCurtesy")
                        .WithMany()
                        .HasForeignKey("TitleOfCurtesyId");

                    b.Navigation("Gender");

                    b.Navigation("Industry");

                    b.Navigation("Nationality");

                    b.Navigation("TitleOfCurtesy");
                });

            modelBuilder.Entity("AngkorAPI.Entities.CustomerContact", b =>
                {
                    b.HasOne("AngkorAPI.Entities.Customer", "Customer")
                        .WithMany("Contacts")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Invoice", b =>
                {
                    b.HasOne("AngkorAPI.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Angkorsoft.Core.Entities.SysList", "ShipVia")
                        .WithMany()
                        .HasForeignKey("ShipViaId");

                    b.Navigation("Customer");

                    b.Navigation("ShipVia");
                });

            modelBuilder.Entity("AngkorAPI.Entities.InvoiceLine", b =>
                {
                    b.HasOne("AngkorAPI.Entities.Invoice", "Invoice")
                        .WithMany("Lines")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngkorAPI.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Item", b =>
                {
                    b.HasOne("AngkorAPI.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Angkorsoft.Core.Entities.SysArea", b =>
                {
                    b.HasOne("Angkorsoft.Core.Entities.SysArea", null)
                        .WithMany("Children")
                        .HasForeignKey("SysAreaId");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Customer", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("AngkorAPI.Entities.Invoice", b =>
                {
                    b.Navigation("Lines");
                });

            modelBuilder.Entity("Angkorsoft.Core.Entities.SysArea", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}