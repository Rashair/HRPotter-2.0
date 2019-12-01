using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class newDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 1, 14, 30, 27, 888, DateTimeKind.Local).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(3159), new DateTime(2019, 12, 11, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4453), new DateTime(2019, 12, 6, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4468) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4498));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4509));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4517));

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "Created", "Description", "JobTitle", "Location", "SalaryFrom", "SalaryTo", "ValidUntil" },
                values: new object[,]
                {
                    { 7, 2, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4521), null, "Tst1", "Venice", 4000, 25000, null },
                    { 8, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4525), null, "Tst2", "Venice", 15000, 25000, null },
                    { 9, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4528), null, "Tst3", "Venice", 15000, 25000, null },
                    { 10, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4532), null, "Tst4", "Venice", 15000, 25000, null },
                    { 11, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4536), null, "Tst5", "Venice", 15000, 25000, null },
                    { 12, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4540), null, "Tst6", "Venice", 15000, 25000, null },
                    { 13, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4543), null, "Tst7", "Venice", 15000, 25000, null },
                    { 14, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4548), null, "Tst8", "Venice", 15000, 25000, null },
                    { 15, 1, new DateTime(2019, 12, 1, 14, 30, 27, 891, DateTimeKind.Local).AddTicks(4551), null, "Tst9", "Venice", 15000, 25000, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15);

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
        }
    }
}
