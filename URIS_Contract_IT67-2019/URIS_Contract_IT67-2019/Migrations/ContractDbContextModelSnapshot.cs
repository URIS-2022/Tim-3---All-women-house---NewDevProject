﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URIS_Contract_IT67_2019.Data;

#nullable disable

namespace URIS_Contract_IT67_2019.Migrations
{
    [DbContext(typeof(ContractDbContext))]
    partial class ContractDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("URIS_Contract_IT67_2019.Entities.Contract", b =>
                {
                    b.Property<Guid>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ContractName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfSeduction")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfSigning")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentGuarantor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfSigning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReferenceNumber")
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.ToTable("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}