using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Data.Migrations
{
    public partial class AddedAdmins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e4eb7aa-c44c-4a9f-a24b-dedd98053ebc", "GUEST@MAIL.COM", "GUEST@MAIL.COM", "AQAAAAEAACcQAAAAEPWVIfcr17FrGeILyOngwujqt8pAG+0MsyYIsdAlQb8BUeWQl9CFZVADpJGR8hNLag==", "daf471dc-dc16-4a77-b661-cadcab8d1711" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ba52961-3842-43c0-8a52-71718010215d", "AQAAAAEAACcQAAAAEJNZMa1D4xq6HH7DEIf1SNHkpgwoUXs+ZOEYBGX1Y+JTbY/lZ/Lv1aQY5BejAQATPg==", "d4c46de0-e697-4b8d-b689-ccec63c460d5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "cd17e5a7-0a4a-45e1-8ee8-0802d3f9ef35", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEEnffTF5FeyiU7bqyezs6z/SSuNUPe6XAUibc84AA7ecVGLcyH7PYbfplv0GEP2nbw==", null, false, "2c6454e1-d7ab-42ef-a1f8-710936d439d1", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 2, "+359123456789", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e6231ab-d1ba-4f4d-ad4c-ed00a9dfd905", "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEH/uJXGdbm8HQlCVS6WHI1r4/KtD2rmYbGgvHnvODpGIRflQpvN3N8LjUFzjCDhRxA==", "c9703f6e-df2c-4f03-a8cd-79fd44c70921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7d55db7-1ba6-4ed2-b4a9-00099c526b12", "AQAAAAEAACcQAAAAEFqYrLZy/6KCQ7l6AsGNvQVy2ehJly3TjwGpH4AIbj0jk2ww0WweWmVDt10aHMonZw==", "1cd5b557-66ed-40e8-98ea-b9d9ca50b788" });
        }
    }
}
