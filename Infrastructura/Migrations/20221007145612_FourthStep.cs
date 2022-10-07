using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class FourthStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Challanges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Challanges_LocationId",
                table: "Challanges",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Challanges_Locations_LocationId",
                table: "Challanges",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Challanges_Locations_LocationId",
                table: "Challanges");

            migrationBuilder.DropIndex(
                name: "IX_Challanges_LocationId",
                table: "Challanges");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Challanges");
        }
    }
}
