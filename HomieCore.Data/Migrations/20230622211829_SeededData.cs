using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupDescription", "GroupName", "LastModifiedTime" },
                values: new object[,]
                {
                    { 1, "Wasted Potential", "Night's Watch", new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9915) },
                    { 2, "PC Port Is Going To Take So Long", "Rosaria Nobels", new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9917) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastModifiedDateTime", "LastName" },
                values: new object[,]
                {
                    { 1, "Jon", new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9830), "Snow" },
                    { 2, "Clive", new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9831), "Rosfield" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssignedUserId", "CompleteByDate", "CreatedUserId", "LastModifiedDateTime", "TaskCreatedDate", "TaskDescription", "TaskName" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9926), 1, new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9927), new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9927), "You know Nuthin Jon Snow", "Free The North" },
                    { 2, 1, new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9929), 2, new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9929), new DateTime(2023, 6, 22, 21, 18, 29, 582, DateTimeKind.Utc).AddTicks(9929), "Will That Really Solve Anything?", "Get Revenge" }
                });
                migrationBuilder.InsertData(
                table: "GroupUser",
                columns: new[] { "GroupsId", "UsersId"},
                values: new object[,]
                {
                    {1,1},
                    {1,2},
                    {2,1},
                    {2,2}
                });
                migrationBuilder.InsertData(
                table: "GroupTask",
                columns: new[] { "GroupsId", "TasksId"},
                values: new object[,]
                {
                    {1,1},
                    {2,2}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
