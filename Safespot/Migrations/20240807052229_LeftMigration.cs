using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safespot.Migrations
{
    /// <inheritdoc />
    public partial class LeftMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "ParkingZoneForCreationDto",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "BusinessSlot",
                table: "ParkingZoneForCreationDto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EconomSlot",
                table: "ParkingZoneForCreationDto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreeSlot",
                table: "ParkingZoneForCreationDto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessSlot",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.DropColumn(
                name: "EconomSlot",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.DropColumn(
                name: "FreeSlot",
                table: "ParkingZoneForCreationDto");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ParkingZoneForCreationDto",
                newName: "MiddleName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ParkingZoneForCreationDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ParkingZoneForCreationDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ParkingZoneForCreationDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "ParkingZoneForCreationDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ParkingZoneForCreationDto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
