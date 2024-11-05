using Microsoft.EntityFrameworkCore;
using WebAplicacion.Model;

namespace WebAplicacion.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EntityConfiguration para user
            var user = modelBuilder.Entity<User>();

            // Nombre de la tabla / propiedades de los campos
            user.ToTable("User");
            user.HasKey(u => u.Id);
            user.Property(u => u.Name).HasColumnType("varchar(128)").IsRequired();
            user.Property(u => u.LastName).HasColumnType("varchar(128)").IsRequired();
            user.Property(u => u.Email).HasColumnType("varchar(255)").IsRequired();
            user.Property(u => u.Password).HasColumnType("varchar(255)").IsRequired();
            user.Property(u => u.PhoneNumber).HasColumnType("varchar(16)").IsRequired();
            user.Property(u => u.Date).HasColumnType("datetime").IsRequired();
            

            //EntityConfiguration para user
            var UsersHistory = modelBuilder.Entity<UsersHistory>();

            // Nombre de la tabla / propiedades de los campos
            UsersHistory.ToTable("UsersHistory");
            UsersHistory.HasKey(u => u.Id);
            UsersHistory.Property(u => u.User).HasColumnType("varchar(255)").IsRequired();
            UsersHistory.Property(u => u.Datecreate).HasColumnType("datetime").IsRequired();
            UsersHistory.Property(u => u.Datemodified).HasColumnType("datetime").IsRequired();

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var client = modelBuilder.Entity<Client>();

            // Nombre de la tabla / propiedades de los campos
            client.ToTable("Clients");
            client.HasKey(x => x.Id);
            client.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            client.Property(x => x.Email).HasColumnType("varchar(128)").IsRequired();
            client.Property(x => x.Direccion).HasColumnType("varchar(128)").IsRequired();
            client.Property(x => x.Telefono).HasColumnType("varchar(16)").IsRequired();

            //Mapeo de relaciones Relacion de uno a muchos
            client.HasMany(x => x.Vehicles).WithOne(x => x.Client).HasForeignKey(x => x.Client_Id).OnDelete(DeleteBehavior.NoAction); // un cliente tiene muchos vehiculos

            //EntityConfiguration para ComentariosClientes
            var comentarioClient = modelBuilder.Entity<ComentariosClientes>();

            // Nombre de la tabla / propiedades de los campos
            comentarioClient.ToTable("ComentariosClientes");
            comentarioClient.HasKey(c => c.Id);
            comentarioClient.Property(c => c.Order_Id).HasColumnType("varchar(16)");
            comentarioClient.Property(c => c.Client_Id).HasColumnType("int").IsRequired();
            comentarioClient.Property(c => c.Comment).HasColumnType("varchar(255)");
            comentarioClient.Property(c => c.Qualification).HasColumnType("varchar(255)");

            //Mapeo de relaciones relacion de uno a uno
            comentarioClient.HasOne(c => c.MaintenanceHistory).WithOne(c => c.ComentariosClientes).HasForeignKey<Maintenance_History>(c => c.Vehicle_Id).OnDelete(DeleteBehavior.NoAction);
            comentarioClient.HasOne(c => c.Client).WithMany(c => c.ComentariosXcliente).HasForeignKey(c => c.Client_Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var order = modelBuilder.Entity<Order>();

            // Nombre de la tabla | propiedades de los campos
            order.ToTable("Orders");
            order.HasKey(x => x.Id);
            order.Property(x => x.DateCreated).HasColumnName("Datetime").IsRequired();
            order.Property(x => x.State).IsRequired();

            //Mapeo de relaciones uno a muchos
            order.HasOne(x => x.Payments).WithMany(x => x.Orders).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction); // de uno a muchos
            //Mapeo de relaciones uno a uno
            order.HasOne(x => x.MaintenanceHistory).WithOne(x => x.Order).HasForeignKey<Order>(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            order.HasOne(x => x.InventoryOrders).WithOne(x => x.Order).HasForeignKey<Order>(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var employee = modelBuilder.Entity<Employee>();

            // Nombre de la tabla / propiedades de los campos
            employee.ToTable("Employee");
            employee.HasKey(x => x.Id);
            employee.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            employee.Property(x => x.Email).HasColumnType("varchar(128)").IsRequired();
            employee.Property(x => x.Phone).HasColumnType("varchar(16)").IsRequired();
            employee.Property(x => x.Position).HasColumnType("varchar(36)").IsRequired();

            //Mapeo de Relacion de uno a muchos
            employee.HasMany(x => x.Orders).WithOne(x => x.Employee).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);//Un empleado tiene muchas órdenes, Una orden pertenece a un solo empleado 

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var inventory = modelBuilder.Entity<Inventory>();

            // Nombre de la tabla / propiedades de los campos
            inventory.ToTable("Inventory");
            inventory.HasKey(x => x.Id);
            inventory.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            inventory.Property(x => x.Description).HasColumnType("varchar(255)").IsRequired();
            inventory.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            inventory.Property(x => x.Price).HasColumnType("varchar(36)").IsRequired();

            //Mapeo de las relaciones
            inventory.HasOne(x => x.Inventory_Purchase).WithOne(x => x.Inventories).HasForeignKey<Inventory>(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var inventoryorders = modelBuilder.Entity<Inventory_Orders>();

            // Nombre de la tabla / propiedades de los campos
            inventoryorders.ToTable("InventoryOrders");
            inventoryorders.HasKey(x => x.Id);
            inventoryorders.Property(x => x.Order_Id).HasColumnType("int").IsRequired();
            inventoryorders.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            inventoryorders.Property(x => x.Inventory_Id).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones
            
            inventoryorders.HasOne(x => x.Inventory).WithOne(x => x.Inventory_Orders).HasForeignKey<Inventory_Orders>(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var InventoryPurchase = modelBuilder.Entity<Inventory_purchase>();

            // Nombre de la tabla / propiedades de los campos
            InventoryPurchase.ToTable("InventoryPurchase");
            InventoryPurchase.HasKey(x => x.Id);
            InventoryPurchase.Property(x => x.Buys_Id).HasColumnType("int").IsRequired();
            InventoryPurchase.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            InventoryPurchase.Property(x => x.Inventory).HasColumnType("varchar(8)").IsRequired();
            InventoryPurchase.Property(x => x.Unit_price).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones de uno a muchos
            InventoryPurchase.HasOne(x => x.Buy).WithMany(x => x.InventoryXpurchase).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var services = modelBuilder.Entity<Service>();

            // Nombre de la tabla / propiedades de los campos
            services.ToTable("Services");
            services.HasKey(x => x.Id);
            services.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            services.Property(x => x.Description).HasColumnType("varchar(255)").IsRequired();
            services.Property(x => x.Price).HasColumnType("varchar(36)").IsRequired();            

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var servicesOrders = modelBuilder.Entity<Services_Orders>();
            // Nombre de la tabla / propiedades de los campos
            servicesOrders.ToTable("ServicesOrders");
            servicesOrders.HasKey(x => x.Id);
            servicesOrders.Property(x => x.Order_Id).HasColumnType("int").IsRequired();
            servicesOrders.Property(x => x.Services_Id).HasColumnType("varchar(8)").IsRequired();
            servicesOrders.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones
            servicesOrders.HasOne(x => x.Order).WithOne(x => x.ServicesOrders).HasForeignKey<Services_Orders>(x => x.Order_Id).OnDelete(DeleteBehavior.NoAction);
            servicesOrders.HasMany(x => x.Service).WithOne(x => x.ServiceOrder).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Buys = modelBuilder.Entity<Buys>();

            // Nombre de la tabla / propiedades de los campos
            Buys.ToTable("Buys");
            Buys.HasKey(x => x.Id);
            Buys.Property(x => x.Supplier_Id).HasColumnType("int").IsRequired();
            Buys.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            Buys.Property(x => x.Total).HasColumnType("varchar(16)").IsRequired();
          
            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Payments = modelBuilder.Entity<Payments>();

            // Nombre de la tabla / propiedades de los campos
            Payments.ToTable("Payments");
            Payments.HasKey(x => x.Id);
            Payments.Property(x => x.Order_Id).HasColumnType("varchar(8)").IsRequired();
            Payments.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            Payments.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            Payments.Property(x => x.Payment_Method).HasColumnType("varchar(32)").IsRequired();

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var MaintenanceHistory = modelBuilder.Entity<Maintenance_History>();


            // Nombre de la tabla / propiedades de los campos
            MaintenanceHistory.ToTable("MaintenanceHistory");
            MaintenanceHistory.HasKey(x => x.Id);
            MaintenanceHistory.Property(x => x.Vehicle_Id).HasColumnType("int").IsRequired();
            MaintenanceHistory.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            MaintenanceHistory.Property(x => x.Details).HasColumnType("varchar(255)").IsRequired();

            //Mapeo de relaciones de uno a uno
            MaintenanceHistory.HasOne(x => x.Order).WithOne(x => x.MaintenanceHistory).HasForeignKey<Maintenance_History>(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Cities = modelBuilder.Entity<Cities>();

            // Nombre de la tabla / propiedades de los campos
            Cities.ToTable("Cities");
            Cities.HasKey(x => x.Id);
            Cities.Property(x => x.Client_Id).HasColumnType("int").IsRequired();
            Cities.Property(x => x.Vehicle_Id).HasColumnType("int").IsRequired();
            Cities.Property(x => x.Motive).HasColumnType("varchar(255)").IsRequired();
            Cities.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            
            //Mapeo de relaciones
            Cities.HasOne(x => x.Client).WithOne(x => x.Cities).HasForeignKey<Cities>(x => x.Client_Id).OnDelete(DeleteBehavior.NoAction);
            Cities.HasOne(x => x.Vehicle).WithOne(x => x.Cities).HasForeignKey<Cities>(x => x.Vehicle_Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Vehicle = modelBuilder.Entity<Vehicle>();
             
            // Nombre de la tabla / propiedades de los campos
            Vehicle.ToTable("Vehicle");
            Vehicle.HasKey(x => x.Id);
            Vehicle.Property(x => x.Client_Id).HasColumnType("int").IsRequired();
            Vehicle.Property(x => x.Brand).HasColumnType("varchar(32)").IsRequired();
            Vehicle.Property(x => x.Model).HasColumnType("varchar(16)").IsRequired();
            Vehicle.Property(x => x.Year).HasColumnType("varchar(8)").IsRequired();
            Vehicle.Property(x => x.Plate).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones
            Vehicle.HasMany(x => x.MaintenanceXhistory).WithOne(x => x.Vehicle).HasForeignKey(x => x.Vehicle_Id).OnDelete(DeleteBehavior.NoAction); // Un vehículo tiene muchos historiales
            Vehicle.HasMany(x => x.Orders).WithOne(x => x.Vehicle).HasForeignKey(x => x.Vehicle_Id).OnDelete(DeleteBehavior.NoAction); // un vehiculo tiene muchas ordenes 


            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Suppliers = modelBuilder.Entity<Suppliers>();

            // Nombre de la tabla / propiedades de los campos
            Suppliers.ToTable("Suppliers");
            Suppliers.HasKey(x => x.Id);
            Suppliers.Property(x => x.Name).HasColumnType("varchar(256)").IsRequired();
            Suppliers.Property(x => x.Contacts).HasColumnType("varchar(256)").IsRequired();
            Suppliers.Property(x => x.Address).HasColumnType("varchar(64)").IsRequired();

            //Mapeo de relaciones
            Suppliers.HasMany(x => x.Buy).WithOne(x => x.Suppliers).HasForeignKey(x => x.Supplier_Id).OnDelete(DeleteBehavior.NoAction);// Un proveedor tiene muchas compras // Una compra tiene un proveedor


            modelBuilder.Entity<UsersHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<Dates>().HasKey(u => u.Id);
            modelBuilder.Entity<Buys>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventory_purchase>().HasKey(u => u.Id);
            modelBuilder.Entity<Employee>().HasKey(u => u.Id);
            modelBuilder.Entity<Maintenance_History>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventory>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventory_Orders>().HasKey(u => u.Id);
            modelBuilder.Entity<Services_Orders>().HasKey(u => u.Id);
            modelBuilder.Entity<Payments>().HasKey(u => u.Id);
            modelBuilder.Entity<Suppliers>().HasKey(u => u.Id);
            modelBuilder.Entity<Service>().HasKey(u => u.Id);
            modelBuilder.Entity<Vehicle>().HasKey(u => u.Id);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UsersHistory> UsersHistory { get; set; }
        public DbSet<ComentariosClientes> ComentariosClientes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Buys> Buys { get; set; }
        public DbSet<Inventory_purchase> Purchasing_inventory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance_History> Maintenance_History { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory_Orders> Inventories_Orders { get; set; }
        public DbSet<Services_Orders> Services_Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}