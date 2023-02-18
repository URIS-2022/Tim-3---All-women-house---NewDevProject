﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URIS_Ministry_IT67_2019.Data;

#nullable disable

namespace URIS_Ministry_IT67_2019.Migrations
{
    [DbContext(typeof(MinistryDbContext))]
    [Migration("20230214000845_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("URIS_Ministry_IT67_2019.Entities.Ministry", b =>
                {
                    b.Property<Guid>("MinistryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Consent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Minister")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MinistryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MinistryId");

                    b.ToTable("Ministries");
                });
#pragma warning restore 612, 618
        }
    }
}
