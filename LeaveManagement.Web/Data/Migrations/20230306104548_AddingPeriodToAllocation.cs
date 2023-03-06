using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19a7d84-998d-487d-ba54-3a8a1368c5c8",
                column: "ConcurrencyStamp",
                value: "aec97428-05c1-420c-b8f8-5fb0e210af08");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b7e84-998e-487e-cb54-3b8b1368d5d8a",
                column: "ConcurrencyStamp",
                value: "33048714-bcce-40ee-b002-d1a427e11737");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2905f62b-1e83-4335-964b-27f4bc8bef41", "AQAAAAEAACcQAAAAEP0ND3S/eRG6MHyPyU8Pr/AYwc+obefp+bzcT79wMBij00RcU1fVJIMeZ8a0e2p6Bw==", "821f3741-2438-4310-b94f-b0da64558474" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "58054dcd-e681-45b9-8e8b-c44d5ddf0498", "AQAAAAEAACcQAAAAEOiPcJIyk3zGYgWvPZfLK2WKo3dRsrQ+PnHb29EOQ30sWxKElsspk0fv70bFTtKI9A==", "a3c44b1c-298d-4082-96d1-a38ed21eeebb" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd245bbf-328e-4030-b950-a12511d41a2a", "AQAAAAEAACcQAAAAENvoh1mFN2FFMtXr/OMIpUDr6yvgM3H3BSY+XFs/+W7rUeH7lrnlciMff4YBTLj//Q==", "65a8d01f-354f-493d-9187-b3555684dec7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "362ef372-a595-4948-a618-b8abd12ed5f9", "AQAAAAEAACcQAAAAEFYHeDUXfoi60ZGwnzrP9YDdxfQITC35zGcggW9DwKbxlVdsTNNzy4EuENBTC3W0Hg==", "ea3312df-0cf4-4a20-8059-419650d5db2b" });
        }
    }
}
