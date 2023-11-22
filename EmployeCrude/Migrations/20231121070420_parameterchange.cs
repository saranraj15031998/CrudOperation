using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeCrude.Migrations
{
    public partial class parameterchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeAddress",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeAddress",
                table: "Employee");
        }
    }
}
