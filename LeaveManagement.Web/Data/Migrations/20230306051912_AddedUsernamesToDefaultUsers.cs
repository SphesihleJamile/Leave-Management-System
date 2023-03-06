using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddedUsernamesToDefaultUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19a7d84-998d-487d-ba54-3a8a1368c5c8",
                column: "ConcurrencyStamp",
                value: "78e7177c-abd4-4fb8-bb92-d9895086d3d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b7e84-998e-487e-cb54-3b8b1368d5d8a",
                column: "ConcurrencyStamp",
                value: "eeb41a17-53c0-4caa-a7d1-8aa6ea272e0d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "dd245bbf-328e-4030-b950-a12511d41a2a", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAENvoh1mFN2FFMtXr/OMIpUDr6yvgM3H3BSY+XFs/+W7rUeH7lrnlciMff4YBTLj//Q==", "65a8d01f-354f-493d-9187-b3555684dec7", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "362ef372-a595-4948-a618-b8abd12ed5f9", true, "USER1@LOCALHOST.COM", "AQAAAAEAACcQAAAAEFYHeDUXfoi60ZGwnzrP9YDdxfQITC35zGcggW9DwKbxlVdsTNNzy4EuENBTC3W0Hg==", "ea3312df-0cf4-4a20-8059-419650d5db2b", "user1@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19a7d84-998d-487d-ba54-3a8a1368c5c8",
                column: "ConcurrencyStamp",
                value: "2df2cef2-5766-461d-98fc-138ac1fc35fc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b7e84-998e-487e-cb54-3b8b1368d5d8a",
                column: "ConcurrencyStamp",
                value: "73957699-fb50-4bce-a4f2-48fe0f771098");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "cf76d2d7-c398-4334-88d1-647a404c179d", false, null, "AQAAAAEAACcQAAAAEPE+jOlS2kUvYCu1q62vkTrlDDr7y47nVs33BZ8Csi09MWRpZV1+qnl+kWylOdfbxw==", "ec84ac34-abdc-4eda-9a2a-6c6f44199c85", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "730a8330-b03f-4385-ab74-fab5bf43b24f", false, null, "AQAAAAEAACcQAAAAEOGEvPpAVcDwJxZO1JUoEtH6XexD7k1nOPXQqipdM+uhy6mXcI/D0y/4Cf9LsZ1tHw==", "70ccc411-ee5f-46c7-9776-3cb174e6f773", null });
        }
    }
}
