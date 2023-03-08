using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagement.Web.Data.Migrations
{
    public partial class AddLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e19a7d84-998d-487d-ba54-3a8a1368c5c8",
                column: "ConcurrencyStamp",
                value: "3d03c053-b2c8-42fc-8dad-e0031cf691f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b7e84-998e-487e-cb54-3b8b1368d5d8a",
                column: "ConcurrencyStamp",
                value: "dcb3173e-9781-429e-a8d7-f2bfa6b95141");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-48d1-ba54-3a8a3719c5c8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b33bd1c3-dbb3-489a-9c6e-2c1f14471469", "AQAAAAEAACcQAAAAECn5MHVpx6DPt6T0WMKnTHrRkpgGL7KUR1bmkx70tSIH36oYcn5KLlDWazR2R7Pllw==", "bfb018ad-e81e-4193-b254-7eb814384d6a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e92a7d04-99bb-50d4-ba54-3a8a2819c8c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b54547f-70bf-4cd6-b57c-bf0278356a14", "AQAAAAEAACcQAAAAEBF7Ly0bOim37g1Nma6ylWhX//bn0zVcTI3IaazL4L1U3GsaNfGHyvlRRcNXWfN0Mw==", "cf68aeb0-79e7-4943-a8fd-0cce1f0338d6" });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypeId",
                table: "LeaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

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
    }
}
