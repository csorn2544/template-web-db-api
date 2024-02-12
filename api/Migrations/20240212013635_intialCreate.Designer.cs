﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using infra.Persistence;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(_dbContext))]
    [Migration("20240212013635_intialCreate")]
    partial class intialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("domain.Entities.PDPA.PdpaConsent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("Con_Code");

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescriptionEN");

                    b.Property<string>("DescriptionTh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescriptionTH");

                    b.Property<string>("DescriptionZh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescriptionZH");

                    b.Property<decimal>("IsDeleted")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TitleEn")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TitleEN");

                    b.Property<string>("TitleTh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TitleTH");

                    b.Property<string>("TitleZh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TitleZH");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("PdpaConsents");
                });

            modelBuilder.Entity("domain.Entities.PDPA.PdpaPrivacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("CreatorUserId")
                        .HasColumnType("bigint");

                    b.Property<long?>("DeleterUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletionTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescriptionEN");

                    b.Property<string>("DescriptionTh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescriptionTH");

                    b.Property<string>("DescriptionZh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("DescriptionZH");

                    b.Property<decimal>("IsDeleted")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime?>("LastModificationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long?>("LastModifierUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("PpCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("PP_Code");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("TitleEn")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TitleEN");

                    b.Property<string>("TitleTh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TitleTH");

                    b.Property<string>("TitleZh")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("TitleZH");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.HasKey("Id");

                    b.ToTable("PdpaPrivacy");
                });
#pragma warning restore 612, 618
        }
    }
}
