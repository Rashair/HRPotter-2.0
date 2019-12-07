using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRPotter.Migrations
{
    public partial class CreatorsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "B2CKey",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "JobOffers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "JobApplications",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "B2CKey", "Name", "RoleId" },
                values: new object[,]
                {
                    { 1, "c3513236-6bcd-4443-bcc3-f39edb2a372b", "admin", 3 },
                    { 2, "48243631-2f99-4553-88f5-8dd9a07a92e3", "testUser", 1 },
                    { 4, "701dcb7e-0a16-46f5-a846-d5a06cbd774c", "stefan", 2 },
                    { 6, "6fa35afc-2051-424b-9d4d-b4933c023081", "hr1", 2 },
                    { 7, "879cc927-1809-47a6-a0c2-ee4f76815b15", "test1", 1 }
                });

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatorId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatorId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "JobApplications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatorId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 654, DateTimeKind.Local).AddTicks(3837), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "CreatorId", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(8145), 4, new DateTime(2019, 12, 17, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(8195) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "CreatorId", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9349), 6, new DateTime(2019, 12, 12, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9363) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9389), 4 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9400), 4 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9452), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9456), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9460), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9463), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9468), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9472), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9476), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9480), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9483), 6 });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Created", "CreatorId" },
                values: new object[] { new DateTime(2019, 12, 7, 0, 16, 6, 656, DateTimeKind.Local).AddTicks(9487), 6 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_B2CKey",
                table: "Users",
                column: "B2CKey",
                unique: true,
                filter: "[B2CKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CreatorId",
                table: "JobOffers",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CreatorId",
                table: "JobApplications",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Users_CreatorId",
                table: "JobApplications",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Users_CreatorId",
                table: "JobOffers",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Users_CreatorId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Users_CreatorId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_Users_B2CKey",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Roles_Name",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CreatorId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CreatorId",
                table: "JobApplications");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "JobApplications");

            migrationBuilder.AlterColumn<string>(
                name: "B2CKey",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 282, DateTimeKind.Local).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(196), new DateTime(2019, 12, 16, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "ValidUntil" },
                values: new object[] { new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1393), new DateTime(2019, 12, 11, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1407) });

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1432));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 5,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 6,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 7,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1457));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 8,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 9,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1465));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 10,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 11,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1473));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 12,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 13,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1481));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 14,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1485));

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 15,
                column: "Created",
                value: new DateTime(2019, 12, 6, 20, 0, 10, 285, DateTimeKind.Local).AddTicks(1489));
        }
    }
}
