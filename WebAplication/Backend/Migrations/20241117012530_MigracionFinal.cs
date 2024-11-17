using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplicacion.Migrations
{
    /// <inheritdoc />
    public partial class MigracionFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Usertype_UsertypeId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UsertypeId",
                table: "User",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_UsertypeId",
                table: "User",
                newName: "IX_User_UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Usertype_UserTypeId",
                table: "User",
                column: "UserTypeId",
                principalTable: "Usertype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Usertype_UserTypeId",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "User",
                newName: "UsertypeId");

            migrationBuilder.RenameIndex(
                name: "IX_User_UserTypeId",
                table: "User",
                newName: "IX_User_UsertypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Usertype_UsertypeId",
                table: "User",
                column: "UsertypeId",
                principalTable: "Usertype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
