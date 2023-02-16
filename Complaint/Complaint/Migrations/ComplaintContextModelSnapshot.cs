﻿// <auto-generated />
using System;
using Complaint.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Complaint.Migrations
{
    [DbContext(typeof(ComplaintContext))]
    partial class ComplaintContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Complaint.Models.ComplaintDto", b =>
                {
                    b.Property<Guid>("IdComplaint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusOfComplaint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeOfComplaint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdComplaint");

                    b.ToTable("Complaint");

                    b.HasData(
                        new
                        {
                            IdComplaint = new Guid("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                            StatusOfComplaint = "Not approved",
                            SubmissionDate = new DateTime(2015, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TypeOfComplaint = "Complaint against the Decision on Leasing"
                        },
                        new
                        {
                            IdComplaint = new Guid("6a411c13-a195-48f7-8dbd-67596c3975c0"),
                            StatusOfComplaint = "Not approved",
                            SubmissionDate = new DateTime(2017, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TypeOfComplaint = "Complaint against the Decision on Leasing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
