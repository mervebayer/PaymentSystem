using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaymentSystem.Migrations
{
    /// <inheritdoc />
    public partial class defaultusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "User",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "IdentityNumber", "InsertDate", "InsertUserId", "IsActive", "LastActivityDate", "LastName", "Password", "Role", "Status", "UpdateDate", "UpdateUserId", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "manager@example.com", "Manager", "1234567890", new DateTime(2024, 1, 21, 20, 47, 12, 391, DateTimeKind.Local).AddTicks(2080), 1, true, new DateTime(2024, 1, 21, 20, 47, 12, 391, DateTimeKind.Local).AddTicks(2067), "User", "a4f64b517678640a0bd1d9b8b4e4f9b4 ", 2, 1, null, null, "manageruser" },
                    { 2, new DateTime(2004, 1, 21, 20, 47, 12, 391, DateTimeKind.Local).AddTicks(2085), "employee@example.com", "Employee", "9876543210", new DateTime(2024, 1, 21, 20, 47, 12, 391, DateTimeKind.Local).AddTicks(2122), 1, true, new DateTime(2024, 1, 21, 20, 47, 12, 391, DateTimeKind.Local).AddTicks(2120), "User", "82eb8d92b631e08895878594ebeea3f1", 1, 1, null, null, "employeeuser" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "User",
                keyColumn: "Id",
                keyValue: 2);
           
        }
    }
}
