using Microsoft.EntityFrameworkCore.Migrations;

namespace HRDataRecordTinTech.Migrations
{
    public partial class addedCertificate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Salary",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<bool>(
                name: "bEducation",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "bJapanese",
                table: "Employees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "bTOEIC",
                table: "Employees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bEducation",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "bJapanese",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "bTOEIC",
                table: "Employees");

            migrationBuilder.AlterColumn<long>(
                name: "Salary",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }
    }
}
