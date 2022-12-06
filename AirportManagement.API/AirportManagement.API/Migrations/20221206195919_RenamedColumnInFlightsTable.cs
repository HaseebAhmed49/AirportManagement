using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class RenamedColumnInFlightsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartingAirportId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "DepartingAirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "Id");
        }
    }
}
