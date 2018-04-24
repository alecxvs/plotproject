using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace plotproject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    License = table.Column<string>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.License);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpot",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeIdId = table.Column<int>(nullable: false),
                    VehicleLicense = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpot", x => x.Number);
                    table.ForeignKey(
                        name: "FK_ParkingSpot_ParkingType_TypeIdId",
                        column: x => x.TypeIdId,
                        principalTable: "ParkingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingSpot_Vehicle_VehicleLicense",
                        column: x => x.VehicleLicense,
                        principalTable: "Vehicle",
                        principalColumn: "License",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InTime = table.Column<DateTime>(nullable: false),
                    OutTime = table.Column<DateTime>(nullable: false),
                    TypeIdId = table.Column<int>(nullable: false),
                    VehicleIdLicense = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_ParkingType_TypeIdId",
                        column: x => x.TypeIdId,
                        principalTable: "ParkingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Vehicle_VehicleIdLicense",
                        column: x => x.VehicleIdLicense,
                        principalTable: "Vehicle",
                        principalColumn: "License",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_TypeIdId",
                table: "ParkingSpot",
                column: "TypeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpot_VehicleLicense",
                table: "ParkingSpot",
                column: "VehicleLicense",
                unique: true,
                filter: "[VehicleLicense] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TypeIdId",
                table: "Ticket",
                column: "TypeIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_VehicleIdLicense",
                table: "Ticket",
                column: "VehicleIdLicense");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpot");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "ParkingType");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
