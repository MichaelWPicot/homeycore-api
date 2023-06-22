using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomieCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededDataWithJoinTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTasks");

            migrationBuilder.DropTable(
                name: "GroupUsers");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupsId = table.Column<int>(type: "integer", nullable: true),
                    TasksId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupTasks_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupTasks_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GroupsId = table.Column<int>(type: "integer", nullable: true),
                    UsersId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupUsers_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupUsers_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "GroupTasks",
                columns: new[] { "Id", "GroupsId", "TasksId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupUsers",
                columns: new[] { "Id", "GroupsId", "UsersId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedTime",
                value: new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8060), new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8061), new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8060) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CompleteByDate", "LastModifiedDateTime", "TaskCreatedDate" },
                values: new object[] { new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8062), new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8063), new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(7962));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastModifiedDateTime",
                value: new DateTime(2023, 6, 22, 21, 35, 14, 912, DateTimeKind.Utc).AddTicks(7964));

            migrationBuilder.CreateIndex(
                name: "IX_GroupTasks_GroupsId",
                table: "GroupTasks",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupTasks_TasksId",
                table: "GroupTasks",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_GroupsId",
                table: "GroupUsers",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUsers_UsersId",
                table: "GroupUsers",
                column: "UsersId");
        }
    }
}
