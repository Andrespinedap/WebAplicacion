﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAplicacion.Context;

#nullable disable

namespace WebAplicacion.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAplicacion.Model.Buys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("Datetime");

                    b.Property<int>("Supplier_Id")
                        .HasColumnType("int");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("Supplier_Id");

                    b.ToTable("Buys", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Datetime");

                    b.Property<string>("Motive")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Vehicle_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id")
                        .IsUnique();

                    b.HasIndex("Vehicle_Id")
                        .IsUnique();

                    b.ToTable("Cities", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ComentariosClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("ComentariosClienteId");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.ComentariosClientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Order_Id")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Qualification")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Response")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id");

                    b.ToTable("ComentariosClientes", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Dates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Motive")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("Vehicle_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("WebAplicacion.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory_Orders", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Inventory_Id")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("InventoryOrders", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory_purchase", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<int>("Buys_Id")
                        .HasColumnType("int");

                    b.Property<string>("Inventory")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Unit_price")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.ToTable("InventoryPurchase", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Maintenance_History", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Datetime");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Vehicle_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Vehicle_Id")
                        .IsUnique();

                    b.ToTable("MaintenanceHistory", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("ComentarioClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2")
                        .HasColumnName("Datetime");

                    b.Property<int>("Employee_Id")
                        .HasColumnType("int");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<int>("Vehicle_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComentarioClienteId");

                    b.HasIndex("Vehicle_Id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Payments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Datetime");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Order_Id")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Payment_Method")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Service", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Services_Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amount")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<string>("Services_Id")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("Order_Id")
                        .IsUnique();

                    b.ToTable("ServicesOrders", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Suppliers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(64)");

                    b.Property<int>("BuysId")
                        .HasColumnType("int");

                    b.Property<string>("Contacts")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("BuysId");

                    b.ToTable("Suppliers", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Modified")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTypeId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.UsersHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Datecreate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datemodified")
                        .HasColumnType("datetime");

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("UsersHistory", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Usertype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usertype");
                });

            modelBuilder.Entity("WebAplicacion.Model.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<int>("Client_Id")
                        .HasColumnType("int");

                    b.Property<int>("MaintenanceHistoryId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.HasKey("Id");

                    b.HasIndex("Client_Id");

                    b.HasIndex("MaintenanceHistoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("WebAplicacion.Model.Buys", b =>
                {
                    b.HasOne("WebAplicacion.Model.Suppliers", "Suppliers")
                        .WithMany("Buy")
                        .HasForeignKey("Supplier_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("WebAplicacion.Model.Cities", b =>
                {
                    b.HasOne("WebAplicacion.Model.Client", "Client")
                        .WithOne("Cities")
                        .HasForeignKey("WebAplicacion.Model.Cities", "Client_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Vehicle", "Vehicle")
                        .WithOne("Cities")
                        .HasForeignKey("WebAplicacion.Model.Cities", "Vehicle_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WebAplicacion.Model.Client", b =>
                {
                    b.HasOne("WebAplicacion.Model.ComentariosClientes", "ComentariosCliente")
                        .WithMany()
                        .HasForeignKey("ComentariosClienteId");

                    b.Navigation("ComentariosCliente");
                });

            modelBuilder.Entity("WebAplicacion.Model.ComentariosClientes", b =>
                {
                    b.HasOne("WebAplicacion.Model.Client", "Client")
                        .WithMany("ComentariosXcliente")
                        .HasForeignKey("Client_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("WebAplicacion.Model.Dates", b =>
                {
                    b.HasOne("WebAplicacion.Model.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WebAplicacion.Model.Employee", b =>
                {
                    b.HasOne("WebAplicacion.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory", b =>
                {
                    b.HasOne("WebAplicacion.Model.Inventory_purchase", "Inventory_Purchase")
                        .WithOne("Inventories")
                        .HasForeignKey("WebAplicacion.Model.Inventory", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Inventory_Purchase");
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory_Orders", b =>
                {
                    b.HasOne("WebAplicacion.Model.Inventory", "Inventory")
                        .WithOne("Inventory_Orders")
                        .HasForeignKey("WebAplicacion.Model.Inventory_Orders", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory_purchase", b =>
                {
                    b.HasOne("WebAplicacion.Model.Buys", "Buy")
                        .WithMany("InventoryXpurchase")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Buy");
                });

            modelBuilder.Entity("WebAplicacion.Model.Maintenance_History", b =>
                {
                    b.HasOne("WebAplicacion.Model.Order", "Order")
                        .WithOne("MaintenanceHistory")
                        .HasForeignKey("WebAplicacion.Model.Maintenance_History", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.ComentariosClientes", "ComentariosClientes")
                        .WithOne("MaintenanceHistory")
                        .HasForeignKey("WebAplicacion.Model.Maintenance_History", "Vehicle_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Vehicle", "Vehicle")
                        .WithMany("MaintenanceXhistory")
                        .HasForeignKey("Vehicle_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ComentariosClientes");

                    b.Navigation("Order");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WebAplicacion.Model.Order", b =>
                {
                    b.HasOne("WebAplicacion.Model.ComentariosClientes", "ComentarioCliente")
                        .WithMany()
                        .HasForeignKey("ComentarioClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Inventory_Orders", "InventoryOrders")
                        .WithOne("Order")
                        .HasForeignKey("WebAplicacion.Model.Order", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Payments", "Payments")
                        .WithMany("Orders")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Vehicle", "Vehicle")
                        .WithMany("Orders")
                        .HasForeignKey("Vehicle_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ComentarioCliente");

                    b.Navigation("Employee");

                    b.Navigation("InventoryOrders");

                    b.Navigation("Payments");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("WebAplicacion.Model.Payments", b =>
                {
                    b.HasOne("WebAplicacion.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebAplicacion.Model.Service", b =>
                {
                    b.HasOne("WebAplicacion.Model.Services_Orders", "ServiceOrder")
                        .WithMany("Service")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ServiceOrder");
                });

            modelBuilder.Entity("WebAplicacion.Model.Services_Orders", b =>
                {
                    b.HasOne("WebAplicacion.Model.Order", "Order")
                        .WithOne("ServicesOrders")
                        .HasForeignKey("WebAplicacion.Model.Services_Orders", "Order_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebAplicacion.Model.Suppliers", b =>
                {
                    b.HasOne("WebAplicacion.Model.Buys", "Buys")
                        .WithMany()
                        .HasForeignKey("BuysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buys");
                });

            modelBuilder.Entity("WebAplicacion.Model.User", b =>
                {
                    b.HasOne("WebAplicacion.Model.Usertype", "Usertype")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usertype");
                });

            modelBuilder.Entity("WebAplicacion.Model.Vehicle", b =>
                {
                    b.HasOne("WebAplicacion.Model.Client", "Client")
                        .WithMany("Vehicles")
                        .HasForeignKey("Client_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Maintenance_History", "MaintenanceHistory")
                        .WithMany()
                        .HasForeignKey("MaintenanceHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAplicacion.Model.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("MaintenanceHistory");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebAplicacion.Model.Buys", b =>
                {
                    b.Navigation("InventoryXpurchase");
                });

            modelBuilder.Entity("WebAplicacion.Model.Client", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("ComentariosXcliente");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("WebAplicacion.Model.ComentariosClientes", b =>
                {
                    b.Navigation("MaintenanceHistory")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAplicacion.Model.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory", b =>
                {
                    b.Navigation("Inventory_Orders")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory_Orders", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAplicacion.Model.Inventory_purchase", b =>
                {
                    b.Navigation("Inventories")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAplicacion.Model.Order", b =>
                {
                    b.Navigation("MaintenanceHistory")
                        .IsRequired();

                    b.Navigation("ServicesOrders")
                        .IsRequired();
                });

            modelBuilder.Entity("WebAplicacion.Model.Payments", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebAplicacion.Model.Services_Orders", b =>
                {
                    b.Navigation("Service");
                });

            modelBuilder.Entity("WebAplicacion.Model.Suppliers", b =>
                {
                    b.Navigation("Buy");
                });

            modelBuilder.Entity("WebAplicacion.Model.Vehicle", b =>
                {
                    b.Navigation("Cities")
                        .IsRequired();

                    b.Navigation("MaintenanceXhistory");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
