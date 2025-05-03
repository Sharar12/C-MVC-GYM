using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYM.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employee",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employee",
                newName: "email");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "experience",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "gender",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "phone",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "schedule",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropColumn(
                name: "address",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "age",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "experience",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "phone",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "role",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "schedule",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Employee",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employee",
                newName: "Email");
        }
    }
}
