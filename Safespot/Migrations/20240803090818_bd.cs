using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Safespot.Migrations
{
    /// <inheritdoc />
    public partial class bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SlotCounter");

            migrationBuilder.AddColumn<int>(
                name: "BusinessSlot",
                table: "ParkingZones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EconomSlot",
                table: "ParkingZones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreeSlot",
                table: "ParkingZones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessSlot",
                table: "ParkingZones");

            migrationBuilder.DropColumn(
                name: "EconomSlot",
                table: "ParkingZones");

            migrationBuilder.DropColumn(
                name: "FreeSlot",
                table: "ParkingZones");

            migrationBuilder.CreateTable(
                name: "SlotCounter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParkingZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessSlots = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EconomSlots = table.Column<int>(type: "int", nullable: false),
                    FreeSlots = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotCounter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlotCounter_ParkingZones_ParkingZoneId",
                        column: x => x.ParkingZoneId,
                        principalTable: "ParkingZones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SlotCounter_ParkingZoneId",
                table: "SlotCounter",
                column: "ParkingZoneId");
        }
    }
}
