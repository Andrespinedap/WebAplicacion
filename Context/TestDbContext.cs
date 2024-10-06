using Microsoft.EntityFrameworkCore;
using WebAplicacion.Model;

namespace WebAplicacion.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
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
            user.Property(u => u.Name).HasColumnType("varchar(148)").IsRequired();
            user.Property(u => u.LastName).HasColumnType("varchar(148)").IsRequired();
            user.Property(u => u.Email).HasColumnType("varchar(256)").IsRequired();
            user.Property(u => u.Password).HasColumnType("varchar(256)").IsRequired();
            user.Property(u => u.PhoneNumber).HasColumnType("varchar(16)").IsRequired();
            user.Property(u => u.Date).HasColumnType("datetime").IsRequired();

            //EntityConfiguration para user
            var UsersHistory = modelBuilder.Entity<UsersHistory>();

            // Nombre de la tabla / propiedades de los campos
            UsersHistory.ToTable("UsersHistory");
            UsersHistory.HasKey(u => u.Id);
            UsersHistory.Property(u => u.User).HasColumnType("varchar(148)").IsRequired();
            UsersHistory.Property(u => u.Datecreate).HasColumnType("datetime").IsRequired();
            UsersHistory.Property(u => u.Modified).HasColumnType("varchar(256)").IsRequired();
            UsersHistory.Property(u => u.ModifiedBy).HasColumnType("varchar(256)").IsRequired();
            UsersHistory.Property(u => u.Datemodified).HasColumnType("datetime").IsRequired();


            //EntityConfiguration para ComentariosClientes
            var comentarioClient = modelBuilder.Entity<ComentariosClientes>();

            // Nombre de la tabla / propiedades de los campos
            comentarioClient.ToTable("ComentariosClientes");
            comentarioClient.HasKey(c => c.Id);
            comentarioClient.Property(c => c.Order_Id).HasColumnType("varchar(16)");
            comentarioClient.Property(c => c.Client_Id).HasColumnType("varchar(16)");
            comentarioClient.Property(c => c.Comment).HasColumnType("varchar(256)");
            comentarioClient.Property(c => c.Qualification).HasColumnType("varchar(256)");

            //Mapeo de relaciones relacion de uno a uno
            comentarioClient.HasOne(c => c.MaintenanceHistory).WithOne(c => c.ComentariosClientes).HasForeignKey<ComentariosClientes>(c => c.Id).OnDelete(DeleteBehavior.NoAction);
            comentarioClient.HasOne(c => c.Client).WithOne(c => c.ComentariosCliente).HasForeignKey<ComentariosClientes>(c => c.Client_Id).OnDelete(DeleteBehavior.NoAction);

            //comentarioClient.HasOne(c => c.Clients).WithMany() De muchos a muchos


            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var order = modelBuilder.Entity<Order>();

            // Nombre de la tabla | propiedades de los campos
            order.ToTable("Orders");
            order.HasKey(x => x.Id);
            order.Property(x => x.DateCreated).HasColumnName("Datetime").IsRequired();
            order.Property(x => x.State).IsRequired();

            //Mapeo de relaciones
            order.HasOne(x => x.Payments).WithOne(x => x.Order).HasForeignKey<Payments>(x => x.Order_Id).OnDelete(DeleteBehavior.NoAction);
            order.HasOne(x => x.ServicesOrders).WithOne(x => x.Order).HasForeignKey<Services_Orders>(x => x.Order_Id).OnDelete(DeleteBehavior.NoAction);
            order.HasOne(x => x.MaintenanceHistory).WithOne(x => x.Order).HasForeignKey<Maintenance_History>(x => x.Vehicle_Id).OnDelete(DeleteBehavior.NoAction);
            order.HasOne(x => x.Vehicle).WithOne(x => x.Order).HasForeignKey<Order>(x => x.Vehicle_Id).OnDelete(DeleteBehavior.NoAction); //muchos a muchos
            order.HasOne(x => x.InventoryOrders).WithOne(x => x.Order).HasForeignKey<Inventory_Orders>(x => x.Order_Id).OnDelete(DeleteBehavior.NoAction);
            order.HasOne(x => x.Employee).WithOne(x => x.Order).HasForeignKey<Order>(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var client = modelBuilder.Entity<Client>();

            // Nombre de la tabla / propiedades de los campos
            client.ToTable("Clients");
            client.HasKey(x => x.Id);
            client.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            client.Property(x => x.Email).HasColumnType("varchar(128)").IsRequired();
            client.Property(x => x.Direccion).HasColumnType("varchar(128)").IsRequired();
            client.Property(x => x.Telefono).HasColumnType("varchar(16)").IsRequired();

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var employee = modelBuilder.Entity<Employee>();

            // Nombre de la tabla / propiedades de los campos
            employee.ToTable("Employee");
            employee.HasKey(x => x.Id);
            employee.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            employee.Property(x => x.email).HasColumnType("varchar(128)").IsRequired();
            employee.Property(x => x.Phone).HasColumnType("varchar(16)").IsRequired();
            employee.Property(x => x.Position).HasColumnType("varchar(36)").IsRequired();

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var inventory = modelBuilder.Entity<Inventory>();

            // Nombre de la tabla / propiedades de los campos
            inventory.ToTable("Inventory");
            inventory.HasKey(x => x.Id);
            inventory.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            inventory.Property(x => x.Description).HasColumnType("varchar(256)").IsRequired();
            inventory.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            inventory.Property(x => x.Price).HasColumnType("varchar(36)").IsRequired();

            //Mapeo de las relaciones
            //inventory.HasMany(x => x.Inventory_Orders).WithOne(x => x.Inventory).HasForeignKey(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var inventoryorders = modelBuilder.Entity<Inventory_Orders>();

            // Nombre de la tabla / propiedades de los campos
            inventoryorders.ToTable("InventoryOrders");
            inventoryorders.HasKey(x => x.Id);
            inventoryorders.Property(x => x.Order_Id).HasColumnType("varchar(8)").IsRequired();
            inventoryorders.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            inventoryorders.Property(x => x.Inventory_Id).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones
            //inventoryorders.HasOne(x => x.Inventory).WithMany(x => x.Inventory_Orders)();
            //inventoryorders.HasOne(x => x.Inventory).WithMany(x => x.Inventory_Orders).HasForeignKey(x => x.Id);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var InventoryPurchase = modelBuilder.Entity<Inventory_purchase>();

            // Nombre de la tabla / propiedades de los campos
            InventoryPurchase.ToTable("InventoryPurchase");
            InventoryPurchase.HasKey(x => x.Id);
            InventoryPurchase.Property(x => x.Buys_Id).HasColumnType("varchar(8)").IsRequired();
            InventoryPurchase.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();
            InventoryPurchase.Property(x => x.Inventory).HasColumnType("varchar(8)").IsRequired();
            InventoryPurchase.Property(x => x.unit_price).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones
            InventoryPurchase.HasOne(x => x.inventory).WithOne(x => x.Inventory_Purchase).HasForeignKey<Inventory_purchase>(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            InventoryPurchase.HasOne(x => x.buys).WithOne(x => x.Inventory_Purchase).HasForeignKey<Inventory_purchase>(x => x.Buys_Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var services = modelBuilder.Entity<Services>();

            // Nombre de la tabla / propiedades de los campos
            services.ToTable("Services");
            services.HasKey(x => x.Id);
            services.Property(x => x.Name).HasColumnType("varchar(64)").IsRequired();
            services.Property(x => x.Description).HasColumnType("varchar(256)").IsRequired();
            services.Property(x => x.Price).HasColumnType("varchar(36)").IsRequired();

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var servicesOrders = modelBuilder.Entity<Services_Orders>();

            // Nombre de la tabla / propiedades de los campos
            servicesOrders.ToTable("ServicesOrders");
            servicesOrders.HasKey(x => x.Id);
            servicesOrders.Property(x => x.Order_Id).HasColumnType("varchar(8)").IsRequired();
            servicesOrders.Property(x => x.Services_Id).HasColumnType("varchar(8)").IsRequired();
            servicesOrders.Property(x => x.Amount).HasColumnType("varchar(8)").IsRequired();

            //Mapeo de relaciones
            // servicesOrders.HasOne(x => x.Order).WithOne(x => x.ServicesOrders).HasForeignKey<Services_Orders>(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            //servicesOrders.HasOne(x => x.Service).WithMany(x => x.)
            
            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Buys = modelBuilder.Entity<Buys>();

            // Nombre de la tabla / propiedades de los campos
            Buys.ToTable("Buys");
            Buys.HasKey(x => x.Id);
            Buys.Property(x => x.supplier_Id).HasColumnType("varchar(8)").IsRequired();
            Buys.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            Buys.Property(x => x.Total).HasColumnType("varchar(16)").IsRequired();

            //Mapeo de relaciones
            Buys.HasOne(x => x.Suppliers).WithOne(x => x.Buys).HasForeignKey<Buys>(x => x.supplier_Id).OnDelete(DeleteBehavior.NoAction);
          
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
            MaintenanceHistory.Property(x => x.Vehicle_Id).HasColumnType("varchar(8)").IsRequired();
            MaintenanceHistory.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            MaintenanceHistory.Property(x => x.Details).HasColumnType("varchar(256)").IsRequired();

            //Mapeo de relaciones
            MaintenanceHistory.HasOne(x => x.Vehicle).WithOne(x => x.MaintenanceHistory).HasForeignKey<Maintenance_History>(x => x.Vehicle_Id).OnDelete(DeleteBehavior.NoAction);
            MaintenanceHistory.HasOne(x => x.Order).WithOne(x => x.MaintenanceHistory).HasForeignKey<Maintenance_History>(x => x.Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Dates = modelBuilder.Entity<Cities>();

            // Nombre de la tabla / propiedades de los campos
            Dates.ToTable("Cities");
            Dates.HasKey(x => x.Id);
            Dates.Property(x => x.Client_Id).HasColumnType("varchar(8)").IsRequired();
            Dates.Property(x => x.Vehicle_Id).HasColumnType("varchar(8)").IsRequired();
            Dates.Property(x => x.Motive).HasColumnType("varchar(256)").IsRequired();
            Dates.Property(x => x.Date).HasColumnType("Datetime").IsRequired();
            
            //Mapeo de relaciones
            Dates.HasOne(x => x.Client).WithOne(x => x.Cities).HasForeignKey<Cities>(x => x.Id).OnDelete(DeleteBehavior.NoAction);
            Dates.HasOne(x => x.Vehicle).WithOne(x => x.Cities).HasForeignKey<Cities>(x => x.Client_Id).OnDelete(DeleteBehavior.NoAction);

            // Asignamos el modelbuilder para la creación de la tabla y sus propiedades
            var Vehicle = modelBuilder.Entity<Vehicle>();

            // Nombre de la tabla / propiedades de los campos
            Vehicle.ToTable("Vehicle");
            Vehicle.HasKey(x => x.Id);
            Vehicle.Property(x => x.Client_Id).HasColumnType("varchar(8)").IsRequired();
            Vehicle.Property(x => x.Brand).HasColumnType("varchar(32)").IsRequired();
            Vehicle.Property(x => x.Model).HasColumnType("varchar(16)").IsRequired();
            Vehicle.Property(x => x.Year).HasColumnType("varchar(8)").IsRequired();
            Vehicle.Property(x => x.Plate).HasColumnType("varchar(8)").IsRequired();

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
            modelBuilder.Entity<Services>().HasKey(u => u.Id);
            modelBuilder.Entity<Vehicle>().HasKey(u => u.Id);



        }

        public DbSet<User> Users { get; set; }
        public DbSet<User> UsersHistory { get; set; }
        public DbSet<ComentariosClientes> ComentariosClientes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dates> Dates { get; set; }
        public DbSet<Buys> Shopping { get; set; }
        public DbSet<Inventory_purchase> Purchasing_inventory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance_History> Maintenance_stories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory_Orders> Inventories_Orders { get; set; }
        public DbSet<Services_Orders> Services_Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Services> Services { get; set; }
    }
}
