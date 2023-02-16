﻿// <auto-generated />
using System;
using Land.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Land.Migrations
{
    [DbContext(typeof(LandContext))]
    partial class LandContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Land.Models.LandDto", b =>
                {
                    b.Property<Guid>("LabelLand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Drainage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormOfProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoilCulture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surface")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LabelLand");

                    b.ToTable("Land");

                    b.HasData(
                        new
                        {
                            LabelLand = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            Drainage = "possible",
                            FormOfProperty = "personal",
                            SoilCulture = "field",
                            Surface = "500m2",
                            Workability = "arable",
                            _Class = "first"
                        },
                        new
                        {
                            LabelLand = new Guid("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                            Drainage = "possible",
                            FormOfProperty = "personal",
                            SoilCulture = "field",
                            Surface = "500m2",
                            Workability = "arable",
                            _Class = "first"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
