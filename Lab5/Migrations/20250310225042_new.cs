using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab5.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7c386178-7cf7-45ea-bd6a-e39e67ba935b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c27ec30b-80cd-416f-a945-294523e76319");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "62d15eca-b69f-4152-8515-d30fbf175f15", 0, "04bca5a3-532f-45dc-9a58-3410b7d8d6d5", "User", null, false, false, null, "Mary", null, null, null, null, false, "b004c20e-2f16-4997-9499-e023d0ceadf2", false, null },
                    { "cd64248b-22dc-49d9-8673-0c0c010d0f4b", 0, "351bd5f7-c6f8-40a5-a010-992994155bac", "User", null, false, false, null, "John", null, null, null, null, false, "bcd76c46-2ff5-4e1e-b36f-0dd5380e1f70", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "62d15eca-b69f-4152-8515-d30fbf175f15");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd64248b-22dc-49d9-8673-0c0c010d0f4b");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7c386178-7cf7-45ea-bd6a-e39e67ba935b", 0, "1c951542-e321-467e-9818-71dfc558d0cb", "User", null, false, false, null, "John", null, null, null, null, false, "5c41fb78-a0d5-4c42-bade-5ed0d8dffb21", false, null },
                    { "c27ec30b-80cd-416f-a945-294523e76319", 0, "12aea10e-35a5-4ec6-8388-3e38da027bb2", "User", null, false, false, null, "Mary", null, null, null, null, false, "b85149dc-53ef-414a-8a0c-536e85ad8fdd", false, null }
                });
        }
    }
}
