﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcurementManagerUltimate.Context;

#nullable disable

namespace ProcurementManagerUltimate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221016045700_ConReceipts")]
    partial class ConReceipts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

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

                    b.ToTable("AspNetRoles", (string)null);
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

                    b.ToTable("AspNetRoleClaims", (string)null);
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

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
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
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.ContractParameters", b =>
                {
                    b.Property<short>("ContractParametersID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<int?>("ContractsID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnType("TEXT");

                    b.Property<byte>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Parameter")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<byte>("Percentage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.HasKey("ContractParametersID");

                    b.HasIndex("ContractsID");

                    b.ToTable("ContractParameters");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Contracts", b =>
                {
                    b.Property<int>("ContractsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amount")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateSigned")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpectedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFlexible")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsMinor")
                        .HasColumnType("INTEGER");

                    b.Property<short>("ItemsID")
                        .HasColumnType("INTEGER");

                    b.Property<short>("MethodsID")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Quantity")
                        .HasColumnType("REAL");

                    b.Property<string>("Receipt")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<short>("SourcesID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<short>("SuppliersID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ContractsID");

                    b.HasIndex("ItemsID");

                    b.HasIndex("MethodsID");

                    b.HasIndex("SourcesID");

                    b.HasIndex("SuppliersID");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Items", b =>
                {
                    b.Property<short>("ItemsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("ItemsID");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemsID = (short)1,
                            Item = "Maize",
                            Unit = "Bag"
                        },
                        new
                        {
                            ItemsID = (short)2,
                            Item = "Rice",
                            Unit = "Bag"
                        },
                        new
                        {
                            ItemsID = (short)3,
                            Item = "Millet",
                            Unit = "Bag"
                        },
                        new
                        {
                            ItemsID = (short)4,
                            Item = "Desktop Computer (Set)",
                            Unit = "pcs"
                        },
                        new
                        {
                            ItemsID = (short)5,
                            Item = "Laptop Computer",
                            Unit = "pcs"
                        },
                        new
                        {
                            ItemsID = (short)6,
                            Item = "Office furniture",
                            Unit = "pcs"
                        },
                        new
                        {
                            ItemsID = (short)7,
                            Item = "Printer",
                            Unit = "pcs"
                        },
                        new
                        {
                            ItemsID = (short)8,
                            Item = "Vehicle",
                            Unit = "unit"
                        },
                        new
                        {
                            ItemsID = (short)9,
                            Item = "Software",
                            Unit = "n/a"
                        },
                        new
                        {
                            ItemsID = (short)10,
                            Item = "Service",
                            Unit = "n/a"
                        });
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Methods", b =>
                {
                    b.Property<short>("MethodsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("MethodsID");

                    b.ToTable("Methods");

                    b.HasData(
                        new
                        {
                            MethodsID = (short)1,
                            Method = "National Competitive Tendering"
                        },
                        new
                        {
                            MethodsID = (short)2,
                            Method = "Sole Sourcing"
                        },
                        new
                        {
                            MethodsID = (short)3,
                            Method = "Single sourcing"
                        },
                        new
                        {
                            MethodsID = (short)4,
                            Method = "Restrictive Tendering"
                        });
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Sources", b =>
                {
                    b.Property<short>("SourcesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("SourcesID");

                    b.ToTable("Sources");

                    b.HasData(
                        new
                        {
                            SourcesID = (short)1,
                            Source = "IGF"
                        },
                        new
                        {
                            SourcesID = (short)2,
                            Source = "District Assembly"
                        },
                        new
                        {
                            SourcesID = (short)3,
                            Source = "Grants and Loans"
                        },
                        new
                        {
                            SourcesID = (short)4,
                            Source = "GOG Funding"
                        });
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Suppliers", b =>
                {
                    b.Property<short>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.Property<string>("TIN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("SupplierID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Timelines", b =>
                {
                    b.Property<int>("TimelinesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<short>("ContractParametersID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateDone")
                        .HasColumnType("TEXT");

                    b.HasKey("TimelinesID");

                    b.HasIndex("ContractParametersID");

                    b.ToTable("Timelines");
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
                    b.HasOne("ProcurementManagerUltimate.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProcurementManagerUltimate.Model.ApplicationUser", null)
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

                    b.HasOne("ProcurementManagerUltimate.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProcurementManagerUltimate.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.ContractParameters", b =>
                {
                    b.HasOne("ProcurementManagerUltimate.Model.Contracts", null)
                        .WithMany("ContractParameters")
                        .HasForeignKey("ContractsID");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Contracts", b =>
                {
                    b.HasOne("ProcurementManagerUltimate.Model.Items", "Items")
                        .WithMany("Contracts")
                        .HasForeignKey("ItemsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcurementManagerUltimate.Model.Methods", "Methods")
                        .WithMany("Contracts")
                        .HasForeignKey("MethodsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcurementManagerUltimate.Model.Sources", "Sources")
                        .WithMany("Contracts")
                        .HasForeignKey("SourcesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcurementManagerUltimate.Model.Suppliers", "Suppliers")
                        .WithMany("Contracts")
                        .HasForeignKey("SuppliersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Items");

                    b.Navigation("Methods");

                    b.Navigation("Sources");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Timelines", b =>
                {
                    b.HasOne("ProcurementManagerUltimate.Model.ContractParameters", "ContractParameters")
                        .WithMany()
                        .HasForeignKey("ContractParametersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContractParameters");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Contracts", b =>
                {
                    b.Navigation("ContractParameters");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Items", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Methods", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Sources", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("ProcurementManagerUltimate.Model.Suppliers", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
