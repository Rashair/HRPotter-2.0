using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HRPotter.Migrations
{
    public partial class indexesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "JobOffers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "JobApplications",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 11, 30, 22, 26, 42, 71, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 11, 30, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(5541), new DateTime(2019, 12, 10, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(5586) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 11, 30, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(6768), new DateTime(2019, 12, 5, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 11, 30, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 11, 30, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(6821));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 11, 30, 22, 26, 42, 74, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_JobTitle",
                table: "JobOffers",
                column: "JobTitle");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_LastName",
                table: "JobApplications",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobOffers_JobTitle",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_LastName",
                table: "JobApplications");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "JobApplications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 11, 4, 1, 25, 23, 297, DateTimeKind.Local).AddTicks(2087));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 11, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(3458), new DateTime(2019, 11, 14, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(3528) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 11, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5052), new DateTime(2019, 11, 9, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5069) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 11, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 11, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5111));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 11, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5122));
        }
    }
}
