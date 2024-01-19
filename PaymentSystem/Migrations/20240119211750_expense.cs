using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSystem.Migrations
{
    /// <inheritdoc />
    public partial class expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_ExpenseRequest_ExpenseRequestId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "ExpenseRequest",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ExpenseRequestId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ExpenseRequestId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.CreateTable(
                name: "Expense",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUserId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expense_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ExpenseId",
                schema: "dbo",
                table: "Payment",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId",
                schema: "dbo",
                table: "Expense",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Expense_ExpenseId",
                schema: "dbo",
                table: "Payment",
                column: "ExpenseId",
                principalSchema: "dbo",
                principalTable: "Expense",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Expense_ExpenseId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.DropTable(
                name: "Expense",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ExpenseId",
                schema: "dbo",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseRequestId",
                schema: "dbo",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExpenseRequest",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertUserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RejectionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseRequest_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ExpenseRequestId",
                schema: "dbo",
                table: "Payment",
                column: "ExpenseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequest_UserId",
                schema: "dbo",
                table: "ExpenseRequest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_ExpenseRequest_ExpenseRequestId",
                schema: "dbo",
                table: "Payment",
                column: "ExpenseRequestId",
                principalSchema: "dbo",
                principalTable: "ExpenseRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
