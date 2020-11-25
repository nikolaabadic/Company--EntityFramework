using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Company.Domain.Migrations
{
    public partial class AddingTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Responsibility",
                columns: table => new
                {
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibility", x => new { x.EmployeeID, x.TaskID });
                    table.ForeignKey(
                        name: "FK_Responsibility_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responsibility_Tasks_TaskID",
                        column: x => x.TaskID,
                        principalTable: "Tasks",
                        principalColumn: "TaskID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Name" },
                values: new object[,]
                {
                    { 1, "Marketing" },
                    { 2, "IT" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskID", "Name" },
                values: new object[,]
                {
                    { 1, "Marketing strategy" },
                    { 2, "App deployment" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Birthday", "DepartmentID", "Lastname", "Name" },
                values: new object[] { 11, new DateTime(1987, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Louis", "Mark" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Birthday", "DepartmentID", "Lastname", "Name" },
                values: new object[] { 20, new DateTime(1989, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Jones", "Luna" });

            migrationBuilder.CreateIndex(
                name: "IX_Responsibility_TaskID",
                table: "Responsibility",
                column: "TaskID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsibility");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
