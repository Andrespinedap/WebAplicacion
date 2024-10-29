using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAplicacion.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(128)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(128)", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Password = table.Column<string>(type: "varchar(255)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<string>(type: "varchar(16)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "varchar(255)", nullable: false),
                    Datecreate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Modified = table.Column<string>(type: "varchar(255)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", nullable: false),
                    Datemodified = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Total = table.Column<string>(type: "varchar(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Buys_Id = table.Column<int>(type: "int", nullable: false),
                    Inventory = table.Column<string>(type: "varchar(8)", nullable: false),
                    Amount = table.Column<string>(type: "varchar(8)", nullable: false),
                    Unit_price = table.Column<string>(type: "varchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryPurchase_Buys_Id",
                        column: x => x.Id,
                        principalTable: "Buys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Contacts = table.Column<string>(type: "varchar(256)", nullable: false),
                    Address = table.Column<string>(type: "varchar(64)", nullable: false),
                    BuysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Buys_BuysId",
                        column: x => x.BuysId,
                        principalTable: "Buys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Amount = table.Column<string>(type: "varchar(8)", nullable: false),
                    Price = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_InventoryPurchase_Id",
                        column: x => x.Id,
                        principalTable: "InventoryPurchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InventoryOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Inventory_Id = table.Column<string>(type: "varchar(8)", nullable: false),
                    Amount = table.Column<string>(type: "varchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryOrders_Inventory_Id",
                        column: x => x.Id,
                        principalTable: "Inventory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Vehicle_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Motive = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(128)", nullable: false),
                    Email = table.Column<string>(type: "varchar(128)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(16)", nullable: false),
                    ComentariosClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComentariosClientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<string>(type: "varchar(16)", nullable: false),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(255)", nullable: false),
                    Qualification = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentariosClientes_Clients_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Vehicle_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dates_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Position = table.Column<string>(type: "varchar(36)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(16)", nullable: false),
                    Email = table.Column<string>(type: "varchar(128)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Vehicle_Id = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Details = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceHistory_ComentariosClientes_Vehicle_Id",
                        column: x => x.Vehicle_Id,
                        principalTable: "ComentariosClientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Vehicle_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Id = table.Column<int>(type: "int", nullable: false),
                    Datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    ComentarioClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ComentariosClientes_ComentarioClienteId",
                        column: x => x.ComentarioClienteId,
                        principalTable: "ComentariosClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Employee_Id",
                        column: x => x.Id,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_InventoryOrders_Id",
                        column: x => x.Id,
                        principalTable: "InventoryOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<string>(type: "varchar(8)", nullable: false),
                    Date = table.Column<DateTime>(type: "Datetime", nullable: false),
                    Amount = table.Column<string>(type: "varchar(8)", nullable: false),
                    Payment_Method = table.Column<string>(type: "varchar(32)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Id = table.Column<int>(type: "int", nullable: false),
                    Services_Id = table.Column<string>(type: "varchar(8)", nullable: false),
                    Amount = table.Column<string>(type: "varchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesOrders_Orders_Order_Id",
                        column: x => x.Order_Id,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "varchar(32)", nullable: false),
                    Model = table.Column<string>(type: "varchar(16)", nullable: false),
                    Year = table.Column<string>(type: "varchar(8)", nullable: false),
                    Plate = table.Column<string>(type: "varchar(8)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceHistoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Clients_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_MaintenanceHistory_MaintenanceHistoryId",
                        column: x => x.MaintenanceHistoryId,
                        principalTable: "MaintenanceHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicle_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: false),
                    Price = table.Column<string>(type: "varchar(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServicesOrders_Id",
                        column: x => x.Id,
                        principalTable: "ServicesOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buys_Supplier_Id",
                table: "Buys",
                column: "Supplier_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Client_Id",
                table: "Cities",
                column: "Client_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Vehicle_Id",
                table: "Cities",
                column: "Vehicle_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ComentariosClienteId",
                table: "Clients",
                column: "ComentariosClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosClientes_Client_Id",
                table: "ComentariosClientes",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_ClientId",
                table: "Dates",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_VehicleId",
                table: "Dates",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_OrderId",
                table: "Employee",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceHistory_Vehicle_Id",
                table: "MaintenanceHistory",
                column: "Vehicle_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ComentarioClienteId",
                table: "Orders",
                column: "ComentarioClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Vehicle_Id",
                table: "Orders",
                column: "Vehicle_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesOrders_Order_Id",
                table: "ServicesOrders",
                column: "Order_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_BuysId",
                table: "Suppliers",
                column: "BuysId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Client_Id",
                table: "Vehicle",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_MaintenanceHistoryId",
                table: "Vehicle",
                column: "MaintenanceHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_OrderId",
                table: "Vehicle",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buys_Suppliers_Supplier_Id",
                table: "Buys",
                column: "Supplier_Id",
                principalTable: "Suppliers",
                principalColumn: "Id");

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
                name: "FK_Clients_ComentariosClientes_ComentariosClienteId",
                table: "Clients",
                column: "ComentariosClienteId",
                principalTable: "ComentariosClientes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dates_Vehicle_VehicleId",
                table: "Dates",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Orders_OrderId",
                table: "Employee",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceHistory_Orders_Id",
                table: "MaintenanceHistory",
                column: "Id",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceHistory_Vehicle_Vehicle_Id",
                table: "MaintenanceHistory",
                column: "Vehicle_Id",
                principalTable: "Vehicle",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_Id",
                table: "Orders",
                column: "Id",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vehicle_Vehicle_Id",
                table: "Orders",
                column: "Vehicle_Id",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buys_Suppliers_Supplier_Id",
                table: "Buys");

            migrationBuilder.DropForeignKey(
                name: "FK_ComentariosClientes_Clients_Client_Id",
                table: "ComentariosClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Clients_Client_Id",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceHistory_Vehicle_Vehicle_Id",
                table: "MaintenanceHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vehicle_Vehicle_Id",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ComentariosClientes_ComentarioClienteId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Orders_OrderId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Orders_OrderId",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UsersHistory");

            migrationBuilder.DropTable(
                name: "ServicesOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "MaintenanceHistory");

            migrationBuilder.DropTable(
                name: "ComentariosClientes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "InventoryOrders");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryPurchase");

            migrationBuilder.DropTable(
                name: "Buys");
        }
    }
}
