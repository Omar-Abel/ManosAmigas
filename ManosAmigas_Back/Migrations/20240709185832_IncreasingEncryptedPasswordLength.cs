using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManosAmigas_Back.Migrations
{
    /// <inheritdoc />
    public partial class IncreasingEncryptedPasswordLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(350)",
                unicode: false,
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "varchar(350)",
                unicode: false,
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);
        }
    }
}
