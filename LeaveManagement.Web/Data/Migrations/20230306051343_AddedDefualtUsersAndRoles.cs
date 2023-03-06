using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedDefualtUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e19a7d84-998d-487d-ba54-3a8a1368c5c8", "2df2cef2-5766-461d-98fc-138ac1fc35fc", "Administrator", "ADMINISTRATOR" },
                    { "f9b7e84-998e-487e-cb54-3b8b1368d5d8a", "73957699-fb50-4bce-a4f2-48fe0f771098", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8", 0, "cf76d2d7-c398-4334-88d1-647a404c179d", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEPE+jOlS2kUvYCu1q62vkTrlDDr7y47nVs33BZ8Csi09MWRpZV1+qnl+kWylOdfbxw==", null, false, "ec84ac34-abdc-4eda-9a2a-6c6f44199c85", "", false, null },
                    { "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5", 0, "730a8330-b03f-4385-ab74-fab5bf43b24f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@localhost.com", false, "System", "User", false, null, "USER1@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEOGEvPpAVcDwJxZO1JUoEtH6XexD7k1nOPXQqipdM+uhy6mXcI/D0y/4Cf9LsZ1tHw==", null, false, "70ccc411-ee5f-46c7-9776-3cb174e6f773", "", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e19a7d84-998d-487d-ba54-3a8a1368c5c8", "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f9b7e84-998e-487e-cb54-3b8b1368d5d8a", "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e19a7d84-998d-487d-ba54-3a8a1368c5c8", "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f9b7e84-998e-487e-cb54-3b8b1368d5d8a", "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19a7d84-998d-487d-ba54-3a8a1368c5c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b7e84-998e-487e-cb54-3b8b1368d5d8a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5");
        }
    }
}
