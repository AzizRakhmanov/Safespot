using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safespot.Migrations
{
    /// <inheritdoc />
    public partial class ReservationIntegratedWithCarPlateNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "CarPlateNumbers");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "CarPlateNumbers");

            migrationBuilder.AddColumn<Guid>(
                name: "CarPlateNumberId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "Reservations",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarPlateNumberId",
                table: "Reservations",
                column: "CarPlateNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_CarPlateNumbers_CarPlateNumberId",
                table: "Reservations",
                column: "CarPlateNumberId",
                principalTable: "CarPlateNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_CarPlateNumbers_CarPlateNumberId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CarPlateNumberId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CarPlateNumberId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Reservations");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "CarPlateNumbers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Paid",
                table: "CarPlateNumbers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }
    }
}
