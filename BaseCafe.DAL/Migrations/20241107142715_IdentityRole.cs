using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BaseCafe.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUser",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "329d3be5-8001-4997-85a9-ebc16be771c2", null, "Admin", "ADMIN" },
                    { "c9bbce7e-7372-47f2-80e9-029ce117f245", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "252d1809-cd07-4ebd-87d1-83cefac3b78c", 0, "55c5fc1a-1d71-4de4-b65e-e14eed798ade", "admin@gmail.com", true, false, null, null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEM+Z5izFnWrz53m8t9fS1e6BMVnlAENTCweQRMyci5Nd1mvUHeyuAA6nwNrQqKfXag==", null, false, "87b82a5e-69c1-4831-87d0-678b208084ae", false, "admin@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUser", "AppUserID", "OrderDate" },
                values: new object[] { null, null, new DateTime(2024, 11, 5, 17, 27, 14, 987, DateTimeKind.Local).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppUser", "AppUserID", "OrderDate" },
                values: new object[] { null, null, new DateTime(2024, 11, 6, 17, 27, 14, 987, DateTimeKind.Local).AddTicks(5593) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppUser", "AppUserID", "OrderDate" },
                values: new object[] { null, null, new DateTime(2024, 11, 7, 17, 27, 14, 987, DateTimeKind.Local).AddTicks(5594) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "329d3be5-8001-4997-85a9-ebc16be771c2", "252d1809-cd07-4ebd-87d1-83cefac3b78c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9bbce7e-7372-47f2-80e9-029ce117f245");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "329d3be5-8001-4997-85a9-ebc16be771c2", "252d1809-cd07-4ebd-87d1-83cefac3b78c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329d3be5-8001-4997-85a9-ebc16be771c2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "252d1809-cd07-4ebd-87d1-83cefac3b78c");

            migrationBuilder.DropColumn(
                name: "AppUser",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2024, 11, 5, 16, 51, 35, 62, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2024, 11, 6, 16, 51, 35, 62, DateTimeKind.Local).AddTicks(3856));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2024, 11, 7, 16, 51, 35, 62, DateTimeKind.Local).AddTicks(3857));
        }
    }
}
