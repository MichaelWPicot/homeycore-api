using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataCorrected : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GroupTask",
                columns: new[] { "GroupsId", "TasksId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7134));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7142), new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7143), new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7142) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7144), new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7145), new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 22, 59, 4, 245, DateTimeKind.Utc).AddTicks(7043));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GroupTask",
                keyColumns: new[] { "GroupsId", "TasksId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GroupTask",
                keyColumns: new[] { "GroupsId", "TasksId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GroupUser",
                keyColumns: new[] { "GroupsId", "UsersId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GroupUser",
                keyColumns: new[] { "GroupsId", "UsersId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GroupUser",
                keyColumns: new[] { "GroupsId", "UsersId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GroupUser",
                keyColumns: new[] { "GroupsId", "UsersId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8338));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8339));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8365), new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8366), new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8366) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8367), new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8368), new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8368) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8247));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 22, 56, 5, 64, DateTimeKind.Utc).AddTicks(8249));
        }
    }
}
