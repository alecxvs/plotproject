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
    [DbContext(typeof(dbContext))]
    [Migration("20180424004628_InitialCreate")]
    partial class InitialCreate
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

                    b.Property<int>("TypeIdId");

                    b.Property<string>("VehicleLicense")
                        .IsConcurrencyToken();

                    b.HasKey("Number");

                    b.HasIndex("TypeIdId");

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

                    b.Property<DateTime>("OutTime");

                    b.Property<int>("TypeIdId");

                    b.Property<string>("VehicleIdLicense")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TypeIdId");

                    b.HasIndex("VehicleIdLicense");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("plotproject.Models.Vehicle", b =>
                {
                    b.Property<string>("License")
                        .ValueGeneratedOnAdd();

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
                    b.HasOne("plotproject.Models.ParkingType", "TypeId")
                        .WithMany()
                        .HasForeignKey("TypeIdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plotproject.Models.Vehicle", "Vehicle")
                        .WithOne("ParkingSpot")
                        .HasForeignKey("plotproject.Models.ParkingSpot", "VehicleLicense");
                });

            modelBuilder.Entity("plotproject.Models.Ticket", b =>
                {
                    b.HasOne("plotproject.Models.ParkingType", "TypeId")
                        .WithMany()
                        .HasForeignKey("TypeIdId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("plotproject.Models.Vehicle", "VehicleId")
                        .WithMany()
                        .HasForeignKey("VehicleIdLicense")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
