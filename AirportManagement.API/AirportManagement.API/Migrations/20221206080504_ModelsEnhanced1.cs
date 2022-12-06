using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirportManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class ModelsEnhanced1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "SecurityChecks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks");

            migrationBuilder.AlterColumn<int>(
                name: "PassangersId",
                table: "SecurityChecks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityChecks_Passangers_PassangersId",
                table: "SecurityChecks",
                column: "PassangersId",
                principalTable: "Passangers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
