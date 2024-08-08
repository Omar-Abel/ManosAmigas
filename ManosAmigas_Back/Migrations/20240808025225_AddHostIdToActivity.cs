using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManosAmigas_Back.Migrations
{
    /// <inheritdoc />
    public partial class AddHostIdToActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HostId",
                table: "Activities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_HostId",
                table: "Activities",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Users_HostId",
                table: "Activities",
                column: "HostId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Users_HostId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_Activities_HostId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Activities");
        }
    }
}
