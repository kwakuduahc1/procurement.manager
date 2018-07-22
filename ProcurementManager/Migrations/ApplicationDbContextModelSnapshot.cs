﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcurementManager.Context;

namespace ProcurementManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("ProcurementManager.Model.ContractParameters", b =>
                {
                    b.Property<short>("ContractParametersID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("ContractParameter")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("ContractsID")
                        .IsRequired();

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("ExpectedDate");

                    b.Property<bool>("IsCompleted");

                    b.Property<byte>("Percentage");

                    b.HasKey("ContractParametersID");

                    b.HasIndex("ContractsID");

                    b.ToTable("ContractParameters");
                });

            modelBuilder.Entity("ProcurementManager.Model.Contracts", b =>
                {
                    b.Property<string>("ContractsID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<double>("Amount");

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Contractor")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateCompleted");

                    b.Property<DateTime>("DateSigned");

                    b.Property<DateTime>("ExpectedDate");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsFlexible");

                    b.Property<short>("ItemsID");

                    b.Property<int?>("ItemsID1");

                    b.Property<short>("MethodsID");

                    b.Property<short>("SourcesID");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("ContractsID");

                    b.HasIndex("ItemsID1");

                    b.HasIndex("MethodsID");

                    b.HasIndex("SourcesID");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("ProcurementManager.Model.Items", b =>
                {
                    b.Property<int>("ItemsID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(5);

                    b.HasKey("ItemsID");

                    b.ToTable("Items");

                    b.HasData(
                        new { ItemsID = 1, Item = "Foodstuff", ShortName = "FDS" },
                        new { ItemsID = 2, Item = "Electronics", ShortName = "ELT" },
                        new { ItemsID = 3, Item = "Stationery", ShortName = "STN" }
                    );
                });

            modelBuilder.Entity("ProcurementManager.Model.Methods", b =>
                {
                    b.Property<short>("MethodsID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("MethodsID");

                    b.ToTable("Methods");

                    b.HasData(
                        new { MethodsID = (short)1, Method = "National Competitive Tendering" },
                        new { MethodsID = (short)2, Method = "Sole Sourcing" },
                        new { MethodsID = (short)3, Method = "Request for quotation" },
                        new { MethodsID = (short)4, Method = "Price quotation" },
                        new { MethodsID = (short)5, Method = "Restrictive Tendering" },
                        new { MethodsID = (short)6, Method = "International Competitive Tendering" },
                        new { MethodsID = (short)7, Method = "Price quotation" }
                    );
                });

            modelBuilder.Entity("ProcurementManager.Model.Sources", b =>
                {
                    b.Property<short>("SourcesID")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SourcesID");

                    b.ToTable("Sources");

                    b.HasData(
                        new { SourcesID = (short)1, Source = "IGF" },
                        new { SourcesID = (short)2, Source = "District Assembly" },
                        new { SourcesID = (short)3, Source = "Grants and Loans" }
                    );
                });

            modelBuilder.Entity("ProcurementManager.Model.Timelines", b =>
                {
                    b.Property<int>("TimelinesID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comments")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Concurrency")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<short>("ContractParametersID");

                    b.Property<DateTime>("DateDone");

                    b.HasKey("TimelinesID");

                    b.HasIndex("ContractParametersID");

                    b.ToTable("Timelines");
                });

            modelBuilder.Entity("ProcurementManager.Model.ContractParameters", b =>
                {
                    b.HasOne("ProcurementManager.Model.Contracts", "Contracts")
                        .WithMany("ContractParameters")
                        .HasForeignKey("ContractsID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProcurementManager.Model.Contracts", b =>
                {
                    b.HasOne("ProcurementManager.Model.Items", "Items")
                        .WithMany("Contracts")
                        .HasForeignKey("ItemsID1");

                    b.HasOne("ProcurementManager.Model.Methods", "Methods")
                        .WithMany("Contracts")
                        .HasForeignKey("MethodsID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProcurementManager.Model.Sources")
                        .WithMany("Contracts")
                        .HasForeignKey("SourcesID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProcurementManager.Model.Timelines", b =>
                {
                    b.HasOne("ProcurementManager.Model.ContractParameters", "ContractParameters")
                        .WithMany()
                        .HasForeignKey("ContractParametersID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
