using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddedUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e6231ab-d1ba-4f4d-ad4c-ed00a9dfd905", "Teodor", "Lesly", "AQAAAAEAACcQAAAAEH/uJXGdbm8HQlCVS6WHI1r4/KtD2rmYbGgvHnvODpGIRflQpvN3N8LjUFzjCDhRxA==", "c9703f6e-df2c-4f03-a8cd-79fd44c70921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7d55db7-1ba6-4ed2-b4a9-00099c526b12", "Linda", "Michaels", "AQAAAAEAACcQAAAAEFqYrLZy/6KCQ7l6AsGNvQVy2ehJly3TjwGpH4AIbj0jk2ww0WweWmVDt10aHMonZw==", "1cd5b557-66ed-40e8-98ea-b9d9ca50b788" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8157ef3f-f8b7-4e4d-9ad0-a366856af8a7", "AQAAAAEAACcQAAAAEEstghD92yECnQNrWpiWNUVegRpdCY2jkj66hsX2lBIP8kqQv34WCeh3CbzhmlJV8g==", "83e820a3-0de9-4e01-9162-57eafb41475d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01d5746c-66b4-4a08-93c0-c910a840fc39", "AQAAAAEAACcQAAAAEAPrEAZnSEy3NX7WaS3b1crgbtuqAV2Ub04HULbbKOLiB06dIQF5o3R/Z6xflkaOaQ==", "cd2e32a2-79a8-478d-9ff2-d2134c3d0a82" });
        }
    }
}
