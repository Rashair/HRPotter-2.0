using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class nextMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Microsoft" },
                    { 2, "Apple" },
                    { 3, "Google" },
                    { 4, "EBR-IT" }
                });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "CompanyId", "Created", "Description", "JobTitle", "Location", "SalaryFrom", "SalaryTo", "ValidUntil" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 12, 4, 1, 25, 23, 297, DateTimeKind.Local).AddTicks(2087), "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", "Backend Developer", "Warsaw", null, 15000, null },
                    { 3, 1, new DateTime(2019, 12, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5052), null, "Manager", "New York", 15000, 25000, new DateTime(2019, 11, 9, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5069) },
                    { 6, 1, new DateTime(2019, 12, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5122), null, "Manager", "Venice", 15000, 25000, null },
                    { 2, 2, new DateTime(2019, 12, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(3458), "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", "Frontend Developer", "Warsaw", 10000, null, new DateTime(2019, 11, 14, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(3528) },
                    { 4, 3, new DateTime(2019, 12, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5096), "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", "Teacher", "Paris", 10000, 15000, null },
                    { 5, 4, new DateTime(2019, 12, 4, 1, 25, 23, 300, DateTimeKind.Local).AddTicks(5111), "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", "Cook", "Venice", 10000, 15000, null }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "Id", "CvUrl", "Description", "Email", "FirstName", "IsStudent", "JobOfferId", "LastName", "Phone", "Status" },
                values: new object[,]
                {
                    { 5, null, null, "wilson@nsa.gov", "Lech", false, 1, "Wilson", null, 1 },
                    { 2, null, null, "smith@nsa.gov", "Bogdan", false, 3, "Smith", null, 1 },
                    { 4, null, null, "jones@nsa.gov", "Bogusław", false, 6, "Jones", "555444333", 1 },
                    { 1, null, "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", "johnson@nsa.gov", "Stefan", false, 2, "Johnson", null, 1 },
                    { 6, null, null, "williams@nsa.gov", "Orfeusz", false, 2, "Williams", "222333111", 1 },
                    { 3, "https://www.google.com/", null, "miller@nsa.gov", "Ambroży", true, 5, "Miller", null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
