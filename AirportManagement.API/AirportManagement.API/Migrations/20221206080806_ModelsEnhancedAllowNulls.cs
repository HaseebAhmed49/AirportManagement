using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class ModelsEnhancedAllowNulls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaggageChecks_Passangers_PassangersId",
                table: "BaggageChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passangers_PassangersId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightManifests_Flights_FlightsId",
                table: "FlightManifests");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "NoFlyLists",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "FlightsId",
                table: "FlightManifests",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "Bookings",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "BaggageChecks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_BaggageChecks_Passangers_PassangersId",
                table: "BaggageChecks",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Passangers_PassangersId",
                table: "Bookings",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightManifests_Flights_FlightsId",
                table: "FlightManifests",
                column: "FlightsId",
                principalTable: "Flights",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaggageChecks_Passangers_PassangersId",
                table: "BaggageChecks");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passangers_PassangersId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightManifests_Flights_FlightsId",
                table: "FlightManifests");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "NoFlyLists",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FlightsId",
                table: "FlightManifests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "Bookings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "BaggageChecks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BaggageChecks_Passangers_PassangersId",
                table: "BaggageChecks",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Passangers_PassangersId",
                table: "Bookings",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightManifests_Flights_FlightsId",
                table: "FlightManifests",
                column: "FlightsId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId",
                principalTable: "Airports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
