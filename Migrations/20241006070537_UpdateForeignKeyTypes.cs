using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplicacion.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Clients_Id",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Vehicle_Client_Id",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosClientes_Clients_Client_Id",
                table: "ComentariosClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryPurchase_Buys_Buys_Id",
                table: "InventoryPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceHistory_Vehicle_Vehicle_Id",
                table: "MaintenanceHistory");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Vehicle_TempId",
                table: "Vehicle");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Vehicle_TempId1",
                table: "Vehicle");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Clients_TempId",
                table: "Clients");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Buys_TempId",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TempId1",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TempId",
                table: "Buys");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Vehicle_Id",
                table: "Cities",
                column: "Vehicle_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Clients_Client_Id",
                table: "Cities",
                column: "Client_Id",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Vehicle_Vehicle_Id",
                table: "Cities",
                column: "Vehicle_Id",
                principalTable: "Vehicle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosClientes_Clients_Client_Id",
                table: "ComentariosClientes",
                column: "Client_Id",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryPurchase_Buys_Buys_Id",
                table: "InventoryPurchase",
                column: "Buys_Id",
                principalTable: "Buys",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceHistory_Vehicle_Vehicle_Id",
                table: "MaintenanceHistory",
                column: "Vehicle_Id",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Clients_Client_Id",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Vehicle_Vehicle_Id",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosClientes_Clients_Client_Id",
                table: "ComentariosClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryPurchase_Buys_Buys_Id",
                table: "InventoryPurchase");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceHistory_Vehicle_Vehicle_Id",
                table: "MaintenanceHistory");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Vehicle_Id",
                table: "Cities");

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                table: "Vehicle",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempId1",
                table: "Vehicle",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                table: "Clients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "TempId",
                table: "Buys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Vehicle_TempId",
                table: "Vehicle",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Vehicle_TempId1",
                table: "Vehicle",
                column: "TempId1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Clients_TempId",
                table: "Clients",
                column: "TempId");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Buys_TempId",
                table: "Buys",
                column: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Clients_Id",
                table: "Cities",
                column: "Id",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Vehicle_Client_Id",
                table: "Cities",
                column: "Client_Id",
                principalTable: "Vehicle",
                principalColumn: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComentariosClientes_Clients_Client_Id",
                table: "ComentariosClientes",
                column: "Client_Id",
                principalTable: "Clients",
                principalColumn: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryPurchase_Buys_Buys_Id",
                table: "InventoryPurchase",
                column: "Buys_Id",
                principalTable: "Buys",
                principalColumn: "TempId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceHistory_Vehicle_Vehicle_Id",
                table: "MaintenanceHistory",
                column: "Vehicle_Id",
                principalTable: "Vehicle",
                principalColumn: "TempId1");
        }
    }
}
