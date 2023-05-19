using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86114841-0c9c-48cf-8f2b-6aa26ef83f14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3297a7b0-35cf-4c28-9462-6c8cd2c0e352", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Company", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5dc7b3d4-4a71-4a40-85b8-dacc1002766d", 0, null, "c8c93e19-e2e4-4877-9c23-6439f7f9a0f1", null, false, "System", null, "Admin", false, null, null, null, "AQAAAAIAAYagAAAAEBUkwmPceSdy5FJ6YoEs4M8bQlyQAthhbCwvvEonB3tk8a/6U5uv7qWCr3egRuRVmg==", null, false, "e4ba3338-b761-4dc2-9a73-244ada8b6e03", false, "administrator" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3297a7b0-35cf-4c28-9462-6c8cd2c0e352");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5dc7b3d4-4a71-4a40-85b8-dacc1002766d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86114841-0c9c-48cf-8f2b-6aa26ef83f14", null, "admin", "ADMIN" });
        }
    }
}
