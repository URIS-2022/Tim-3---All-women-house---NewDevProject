﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using URIS_DOKUMENTACIJA_IT72.Data;

#nullable disable

namespace URIS_DOKUMENTACIJA_IT72.Migrations
{
    [DbContext(typeof(DocumentationAPIDbContext))]
    [Migration("20230216141126_initMigration")]
    partial class initMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.BiddingProgram", b =>
                {
                    b.Property<Guid>("BiddingProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("int");

                    b.HasKey("BiddingProgramId");

                    b.HasIndex("DocumentId");

                    b.ToTable("BiddingPrograms");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.Decision", b =>
                {
                    b.Property<Guid>("DecisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumberOfDecision")
                        .HasColumnType("int");

                    b.Property<string>("ParliamentaryDecision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DecisionId");

                    b.HasIndex("DocumentId");

                    b.ToTable("Decisions");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.Document", b =>
                {
                    b.Property<Guid>("DocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DocumentationListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReferenceNumber")
                        .HasColumnType("int");

                    b.HasKey("DocumentId");

                    b.HasIndex("DocumentationListId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.DocumentationList", b =>
                {
                    b.Property<Guid>("DocumentationListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DocumentationListId");

                    b.ToTable("DocumentationLists");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.BiddingProgram", b =>
                {
                    b.HasOne("URIS_DOKUMENTACIJA_IT72.Models.Domain.Document", "Document")
                        .WithMany("BiddingPrograms")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.Decision", b =>
                {
                    b.HasOne("URIS_DOKUMENTACIJA_IT72.Models.Domain.Document", "Document")
                        .WithMany("Decisions")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.Document", b =>
                {
                    b.HasOne("URIS_DOKUMENTACIJA_IT72.Models.Domain.DocumentationList", "DocumentationLists")
                        .WithMany("Documents")
                        .HasForeignKey("DocumentationListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentationLists");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.Document", b =>
                {
                    b.Navigation("BiddingPrograms");

                    b.Navigation("Decisions");
                });

            modelBuilder.Entity("URIS_DOKUMENTACIJA_IT72.Models.Domain.DocumentationList", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
