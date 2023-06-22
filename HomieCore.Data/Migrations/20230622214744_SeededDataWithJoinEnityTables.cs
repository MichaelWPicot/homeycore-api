using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataWithJoinEnityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7881));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7882));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7894), new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7895), new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7895) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7897), new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7898), new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7897) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7767));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 21, 47, 44, 284, DateTimeKind.Utc).AddTicks(7768));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(135));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(137));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(150), new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(151), new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(153), new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(153), new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(153) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(35));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 21, 46, 10, 940, DateTimeKind.Utc).AddTicks(37));
        }
    }
}
