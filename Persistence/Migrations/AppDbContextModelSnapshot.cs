﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Domain.Entities.Contractor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contractors");
                });

            modelBuilder.Entity("Domain.Entities.Identity.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Entities.MBSheetAggregate.MBSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AcceptingDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AcceptingOfficer")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int>("MeasurementBookId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MeasurementDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MeasurementOfficer")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<long>("ValidationDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ValidationOfficer")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementBookId");

                    b.ToTable("MBSheets");
                });

            modelBuilder.Entity("Domain.Entities.MBSheetAggregate.MBSheetItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("Dimension")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int?>("MBSheetId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MBookItemId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("UnitRate")
                        .HasColumnType("REAL");

                    b.Property<string>("Uom")
                        .HasColumnType("TEXT");

                    b.Property<float>("Value1")
                        .HasColumnType("REAL");

                    b.Property<float>("Value2")
                        .HasColumnType("REAL");

                    b.Property<float>("Value3")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("MBSheetId");

                    b.HasIndex("MBookItemId");

                    b.ToTable("MBSheetItem");
                });

            modelBuilder.Entity("Domain.Entities.MeasurementBookAggregate.MBookItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int?>("MeasurementBookId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkOrderItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementBookId");

                    b.HasIndex("WorkOrderItemId")
                        .IsUnique();

                    b.ToTable("MBookItem");
                });

            modelBuilder.Entity("Domain.Entities.MeasurementBookAggregate.MeasurementBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("MeasurementOfficer")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("ValidatingOfficer")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkOrderId");

                    b.ToTable("MeasurementBooks");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Domain.Entities.Uom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<int>("Dimension")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Uoms");
                });

            modelBuilder.Entity("Domain.Entities.WorkOrderAggregate.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("AgreementDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AgreementNo")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<long>("CommencementDate")
                        .HasColumnType("INTEGER");

                    b.Property<long>("CompletionDate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContractorId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("EngineerInCharge")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<long>("OrderDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContractorId");

                    b.HasIndex("ProjectId");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("Domain.Entities.WorkOrderAggregate.WorkOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("Created")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<float>("PoQuantity")
                        .HasColumnType("REAL");

                    b.Property<double>("UnitRate")
                        .HasColumnType("REAL");

                    b.Property<int>("UomId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkOrderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UomId");

                    b.HasIndex("WorkOrderId");

                    b.ToTable("WorkOrderItem");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Entities.MBSheetAggregate.MBSheet", b =>
                {
                    b.HasOne("Domain.Entities.MeasurementBookAggregate.MeasurementBook", "MeasurementBook")
                        .WithMany()
                        .HasForeignKey("MeasurementBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeasurementBook");
                });

            modelBuilder.Entity("Domain.Entities.MBSheetAggregate.MBSheetItem", b =>
                {
                    b.HasOne("Domain.Entities.MBSheetAggregate.MBSheet", null)
                        .WithMany("Items")
                        .HasForeignKey("MBSheetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.MeasurementBookAggregate.MBookItem", "MBookItem")
                        .WithMany("MBSheetItems")
                        .HasForeignKey("MBookItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MBookItem");
                });

            modelBuilder.Entity("Domain.Entities.MeasurementBookAggregate.MBookItem", b =>
                {
                    b.HasOne("Domain.Entities.MeasurementBookAggregate.MeasurementBook", null)
                        .WithMany("Items")
                        .HasForeignKey("MeasurementBookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.Entities.WorkOrderAggregate.WorkOrderItem", "WorkOrderItem")
                        .WithOne("MBookItem")
                        .HasForeignKey("Domain.Entities.MeasurementBookAggregate.MBookItem", "WorkOrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkOrderItem");
                });

            modelBuilder.Entity("Domain.Entities.MeasurementBookAggregate.MeasurementBook", b =>
                {
                    b.HasOne("Domain.Entities.WorkOrderAggregate.WorkOrder", "WorkOrder")
                        .WithMany("MeasurementBooks")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("Domain.Entities.WorkOrderAggregate.WorkOrder", b =>
                {
                    b.HasOne("Domain.Entities.Contractor", "Contractor")
                        .WithMany("WorkOrders")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Project", "Project")
                        .WithMany("WorkOrders")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Domain.Entities.WorkOrderAggregate.WorkOrderItem", b =>
                {
                    b.HasOne("Domain.Entities.Uom", "Uom")
                        .WithMany()
                        .HasForeignKey("UomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.WorkOrderAggregate.WorkOrder", null)
                        .WithMany("Items")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Uom");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.Identity.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Contractor", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("Domain.Entities.MBSheetAggregate.MBSheet", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Domain.Entities.MeasurementBookAggregate.MBookItem", b =>
                {
                    b.Navigation("MBSheetItems");
                });

            modelBuilder.Entity("Domain.Entities.MeasurementBookAggregate.MeasurementBook", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Domain.Entities.Project", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("Domain.Entities.WorkOrderAggregate.WorkOrder", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("MeasurementBooks");
                });

            modelBuilder.Entity("Domain.Entities.WorkOrderAggregate.WorkOrderItem", b =>
                {
                    b.Navigation("MBookItem");
                });
#pragma warning restore 612, 618
        }
    }
}
