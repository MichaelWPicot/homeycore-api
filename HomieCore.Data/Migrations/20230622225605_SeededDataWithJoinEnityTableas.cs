using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataWithJoinEnityTableas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupUser_GroupsId",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTask",
                table: "GroupTask");

            migrationBuilder.DropIndex(
                name: "IX_GroupTask_GroupsId",
                table: "GroupTask");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTask",
                table: "GroupTask",
                columns: new[] { "GroupsId", "TasksId" });

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

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTask_TasksId",
                table: "GroupTask",
                column: "TasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser");

            migrationBuilder.DropIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTask",
                table: "GroupTask");

            migrationBuilder.DropIndex(
                name: "IX_GroupTask_TasksId",
                table: "GroupTask");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupUser",
                table: "GroupUser",
                columns: new[] { "UsersId", "GroupsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTask",
                table: "GroupTask",
                columns: new[] { "TasksId", "GroupsId" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5816), new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5817), new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5817) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5820), new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5821), new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 22, 16, 29, 156, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_GroupsId",
                table: "GroupUser",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTask_GroupsId",
                table: "GroupTask",
                column: "GroupsId");
        }
    }
}
