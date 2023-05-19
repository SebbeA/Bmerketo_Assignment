using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations.Identity
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9048dc6-f03c-4fee-87a4-3ffe05013737", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Company", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da530c49-cc04-4398-8bf6-6272dc08116e", 0, null, "e0228355-2d77-41a3-a740-5d0805e8d2ce", "administrator@domian.com", false, "System", null, "Admin", false, null, null, null, "AQAAAAIAAYagAAAAEO7GhiFBl7xiGj2GAUmqZs1GsYiEnzrwVbDGxNbLmFzgEEY3oBcOie1tgqJgcXTe4A==", null, false, "577efceb-eccb-423c-9208-5910bf571b64", false, "administrator@domian.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e9048dc6-f03c-4fee-87a4-3ffe05013737", "da530c49-cc04-4398-8bf6-6272dc08116e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e9048dc6-f03c-4fee-87a4-3ffe05013737", "da530c49-cc04-4398-8bf6-6272dc08116e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9048dc6-f03c-4fee-87a4-3ffe05013737");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da530c49-cc04-4398-8bf6-6272dc08116e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1", null, "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Company", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, null, "22a2c3ac-3e04-4ebd-bbc9-15ba129701ec", null, false, "System", null, "Admin", false, null, null, null, "AQAAAAIAAYagAAAAEMRPteuz15HkqVLS9l8FKQzYcmyMzZeEnv+dhkcLkgbKCSkq/nwwiBwjffMq0MUsfg==", null, false, "ec9d14fa-b609-4ce0-aef4-3a25d5fce2b6", false, "administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }
    }
}
