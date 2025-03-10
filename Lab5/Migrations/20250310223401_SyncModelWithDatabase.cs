using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab5.Migrations
{
    /// <inheritdoc />
    public partial class SyncModelWithDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04e204cc-91d7-405a-811c-9e5d571938c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44ea2c83-6046-4919-8e3c-af5f9dc4ebc9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7c386178-7cf7-45ea-bd6a-e39e67ba935b", 0, "1c951542-e321-467e-9818-71dfc558d0cb", "User", null, false, false, null, "John", null, null, null, null, false, "5c41fb78-a0d5-4c42-bade-5ed0d8dffb21", false, null },
                    { "c27ec30b-80cd-416f-a945-294523e76319", 0, "12aea10e-35a5-4ec6-8388-3e38da027bb2", "User", null, false, false, null, "Mary", null, null, null, null, false, "b85149dc-53ef-414a-8a0c-536e85ad8fdd", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c386178-7cf7-45ea-bd6a-e39e67ba935b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c27ec30b-80cd-416f-a945-294523e76319");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "04e204cc-91d7-405a-811c-9e5d571938c8", 0, "559b7cbd-a14f-483d-baff-8318cc0ee6d5", "User", null, false, false, null, "John", null, null, null, null, false, "77696556-ddff-4d4a-a840-76399a390ab1", false, null },
                    { "44ea2c83-6046-4919-8e3c-af5f9dc4ebc9", 0, "b915d079-94f0-4e1f-80b0-42b339c5a740", "User", null, false, false, null, "Mary", null, null, null, null, false, "67a65f3e-dbea-4a42-a79a-de50db7c8848", false, null }
                });
        }
    }
}
