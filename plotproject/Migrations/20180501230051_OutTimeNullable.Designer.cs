﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using plotproject.Models;
using System;

namespace plotproject.Migrations
{
    [DbContext(typeof(PLotContext))]
    [Migration("20180501230051_OutTimeNullable")]
    partial class OutTimeNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("plotproject.Models.ParkingSpot", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TypeId");

                    b.Property<string>("VehicleLicense")
                        .IsConcurrencyToken();

                    b.HasKey("Number");

                    b.HasIndex("TypeId");

                    b.HasIndex("VehicleLicense")
                        .IsUnique()
                        .HasFilter("[VehicleLicense] IS NOT NULL");

                    b.ToTable("ParkingSpot");
                });

            modelBuilder.Entity("plotproject.Models.ParkingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("ParkingType");
                });

            modelBuilder.Entity("plotproject.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("InTime");

                    b.Property<DateTime?>("OutTime")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(null);

                    b.Property<int>("TypeId");

                    b.Property<string>("VehicleLicense")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.HasIndex("VehicleLicense");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("plotproject.Models.Vehicle", b =>
                {
                    b.Property<string>("License")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6);

                    b.Property<string>("Color")
                        .IsRequired();

                    b.Property<string>("Make")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.HasKey("License");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("plotproject.Models.ParkingSpot", b =>
                {
                    b.HasOne("plotproject.Models.ParkingType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plotproject.Models.Vehicle", "Vehicle")
                        .WithOne("ParkingSpot")
                        .HasForeignKey("plotproject.Models.ParkingSpot", "VehicleLicense");
                });

            modelBuilder.Entity("plotproject.Models.Ticket", b =>
                {
                    b.HasOne("plotproject.Models.ParkingType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plotproject.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleLicense")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
