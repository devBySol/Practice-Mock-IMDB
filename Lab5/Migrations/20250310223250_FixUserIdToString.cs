using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab5.Migrations
{
    /// <inheritdoc />
    public partial class FixUserIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "03656bf4-7826-44a8-a8d3-ba6545bd4408");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "753559f4-fb5a-4a3a-9a30-c63ab804b501");

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
                    { "04e204cc-91d7-405a-811c-9e5d571938c8", 0, "559b7cbd-a14f-483d-baff-8318cc0ee6d5", "User", null, false, false, null, "John", null, null, null, null, false, "77696556-ddff-4d4a-a840-76399a390ab1", false, null },
                    { "44ea2c83-6046-4919-8e3c-af5f9dc4ebc9", 0, "b915d079-94f0-4e1f-80b0-42b339c5a740", "User", null, false, false, null, "Mary", null, null, null, null, false, "67a65f3e-dbea-4a42-a79a-de50db7c8848", false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04e204cc-91d7-405a-811c-9e5d571938c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44ea2c83-6046-4919-8e3c-af5f9dc4ebc9");

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
                    { "03656bf4-7826-44a8-a8d3-ba6545bd4408", 0, "f465406a-2790-4371-8be7-1b30b29923ff", "User", null, false, false, null, "John", null, null, null, null, false, "eeef0975-961f-46bd-a928-28822f4ecf79", false, null },
                    { "753559f4-fb5a-4a3a-9a30-c63ab804b501", 0, "c0210b83-5d0d-46db-9dad-5dc4887bbed6", "User", null, false, false, null, "Mary", null, null, null, null, false, "ad4834ff-6cb3-4c55-b808-440e1576b44c", false, null }
                });
        }
    }
}
