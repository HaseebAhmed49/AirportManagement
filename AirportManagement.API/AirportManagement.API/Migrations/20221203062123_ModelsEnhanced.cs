using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class ModelsEnhanced : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Passangers_PassangersId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightManifests_Flights_FlightsId",
                table: "FlightManifests");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_AirportId1",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AirportId1",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AirportId1",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "SecurityChecks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "NoFlyLists",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartureAirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddColumn<int>(
                name: "PassangersId",
                table: "BaggageChecks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivingAirportId",
                table: "Flights",
                column: "ArrivingAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flights",
                column: "DepartureAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_BaggageChecks_PassangersId",
                table: "BaggageChecks",
                column: "PassangersId");

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
                name: "FK_Flights_Airports_ArrivingAirportId",
                table: "Flights",
                column: "ArrivingAirportId",
                principalTable: "Airports",
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

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_Flights_Airports_ArrivingAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Airports_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists");

            migrationBuilder.DropForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks");

            migrationBuilder.DropIndex(
                name: "IX_Flights_ArrivingAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_BaggageChecks_PassangersId",
                table: "BaggageChecks");

            migrationBuilder.DropColumn(
                name: "DepartureAirportId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "PassangersId",
                table: "BaggageChecks");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "SecurityChecks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "NoFlyLists",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "AirportId",
                table: "Flights",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirportId1",
                table: "Flights",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId",
                table: "Flights",
                column: "AirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportId1",
                table: "Flights",
                column: "AirportId1");

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
                name: "FK_Flights_Airports_AirportId",
                table: "Flights",
                column: "AirportId",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Airports_AirportId1",
                table: "Flights",
                column: "AirportId1",
                principalTable: "Airports",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoFlyLists_Passangers_PassangersId",
                table: "NoFlyLists",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id");
        }
    }
}
