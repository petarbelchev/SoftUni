using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artillery.Data.Migrations
{
    public partial class UpdatedManufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_ManufacturerName",
                table: "Manufacturers",
                column: "ManufacturerName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_ManufacturerName",
                table: "Manufacturers");
        }
    }
}
