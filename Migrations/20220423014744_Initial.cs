using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CitasMantenimiento.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusVehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaque = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    AppointmentTimeId = table.Column<int>(type: "int", nullable: true),
                    statusVehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentTimes_AppointmentTimeId",
                        column: x => x.AppointmentTimeId,
                        principalTable: "AppointmentTimes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_StatusVehicles_statusVehicleId",
                        column: x => x.statusVehicleId,
                        principalTable: "StatusVehicles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentTimeId",
                table: "Appointments",
                column: "AppointmentTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_statusVehicleId",
                table: "Appointments",
                column: "statusVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentTimes_Time",
                table: "AppointmentTimes",
                column: "Time",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StatusVehicles_Status",
                table: "StatusVehicles",
                column: "Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Plaque",
                table: "Vehicles",
                column: "Plaque",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentTimes");

            migrationBuilder.DropTable(
                name: "StatusVehicles");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
