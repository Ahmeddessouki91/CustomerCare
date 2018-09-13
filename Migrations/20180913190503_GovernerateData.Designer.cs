﻿// <auto-generated />
using System;
using CustomerCare.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomerCare.Migrations
{
    [DbContext(typeof(CuCareDbContext))]
    [Migration("20180913190503_GovernerateData")]
    partial class GovernerateData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CustomerCare.Core.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activated");

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<int>("GovernerateId");

                    b.Property<int>("JobId");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("GovernerateId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Governerate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Governerates");
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Interaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.ToTable("Interactions");
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55);

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("CustomerCare.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Deactive");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsAdmin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Customer", b =>
                {
                    b.HasOne("CustomerCare.Core.Models.Governerate", "Governerate")
                        .WithMany()
                        .HasForeignKey("GovernerateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CustomerCare.Core.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CustomerCare.Core.Models.User", "User")
                        .WithMany("Customers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Governerate", b =>
                {
                    b.HasOne("CustomerCare.Core.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CustomerCare.Core.Models.Interaction", b =>
                {
                    b.HasOne("CustomerCare.Core.Models.Customer", "Customer")
                        .WithMany("Interactions")
                        .HasForeignKey("CustomerId");

                    b.HasOne("CustomerCare.Core.Models.User", "User")
                        .WithMany("Interactions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
