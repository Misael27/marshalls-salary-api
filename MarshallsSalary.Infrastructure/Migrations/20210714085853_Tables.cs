using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarshallsSalary.Infrastructure.Migrations
{
    public partial class Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionId);
                });

            migrationBuilder.CreateTable(
                name: "Office",
                columns: table => new
                {
                    OfficeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Office", x => x.OfficeId);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    OfficeId = table.Column<int>(nullable: false),
                    EmployeeCode = table.Column<string>(nullable: true),
                    EmployeeName = table.Column<string>(nullable: true),
                    EmployeeSurname = table.Column<string>(nullable: true),
                    DivisionId = table.Column<int>(nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    IdentificationNumber = table.Column<string>(nullable: true),
                    BaseSalary = table.Column<float>(nullable: false),
                    ProductionBonus = table.Column<float>(nullable: false),
                    CompensatioBonus = table.Column<float>(nullable: false),
                    Commission = table.Column<float>(nullable: false),
                    Contributions = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Office_OfficeId",
                        column: x => x.OfficeId,
                        principalTable: "Office",
                        principalColumn: "OfficeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_DivisionId",
                table: "EmployeeSalary",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_OfficeId",
                table: "EmployeeSalary",
                column: "OfficeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_PositionId",
                table: "EmployeeSalary",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "Office");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
