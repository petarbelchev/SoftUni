using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaporStore.Data.Migrations
{
    public partial class UpdatedPurchasesDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Cards_CardId",
                table: "Purchase");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchase_Games_GameId",
                table: "Purchase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase");

            migrationBuilder.RenameTable(
                name: "Purchase",
                newName: "Purchases");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_GameId",
                table: "Purchases",
                newName: "IX_Purchases_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchase_CardId",
                table: "Purchases",
                newName: "IX_Purchases_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Cards_CardId",
                table: "Purchases",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Games_GameId",
                table: "Purchases",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Cards_CardId",
                table: "Purchases");

            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Games_GameId",
                table: "Purchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Purchases",
                table: "Purchases");

            migrationBuilder.RenameTable(
                name: "Purchases",
                newName: "Purchase");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_GameId",
                table: "Purchase",
                newName: "IX_Purchase_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Purchases_CardId",
                table: "Purchase",
                newName: "IX_Purchase_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Purchase",
                table: "Purchase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Cards_CardId",
                table: "Purchase",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchase_Games_GameId",
                table: "Purchase",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
