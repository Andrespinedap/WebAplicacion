using Microsoft.EntityFrameworkCore;
using WebAplicacion.Model;

namespace WebAplicacion.Context
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Client> clients { get; set; }
        public DbSet<Comentari_Client> Clients { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Buys> Shopping { get; set; }
        public DbSet<Inventory_purchase> purchasing_inventory { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Maintenance_History> Maintenance_sotories { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory_Orders> Inventories_Orders { get; set; }
        public DbSet<Services_Orders> Services_Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Services> Services { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //EntityConfiguration para user
            var user = modelBuilder.Entity<User>();
            //Nombre de a tabla / propiedades de los campos 
            user.ToTable("User");
            user.HasKey(u => u.Id);
            user.Property(u => u.Name).HasColumnType("varchar(128)").IsRequired();
            user.Property(u => u.LastName).HasColumnType("varchar(128)").IsRequired();
            user.Property(u => u.Email).HasColumnType("varchar(64)").IsRequired();
            user.Property(u => u.Password).HasColumnType("varchar(16)").IsRequired();
            user.Property(u => u.PhoneNumber).HasColumnType("varchar(16)").IsRequired();
            user.Property(u => u.UserName).HasColumnType("varchar(32)").IsRequired();
            user.Property(u => u.date).HasColumnType("Date").IsRequired();
             
          

            var client = modelBuilder.Entity<Client>();

            client.ToTable("Client");
            client.HasKey(u => u.Id);
            client.Property(u => u.Name).HasColumnType("varchar (16)").IsRequired();
            client.Property(u => u.Email).HasColumnType("varchar (256)").IsRequired();
            client.Property(u => u.LastName).HasColumnType("varchar(64)");
            client.Property(u => u.Phone).HasColumnType("varchar(16)").IsRequired();

            var buys= modelBuilder.Entity<Buys>();

            buys.ToTable("Buys");
            buys.HasKey(u => u.Id);
            buys.Property(u => u.supplier_Id).HasColumnType("int");

            modelBuilder.Entity<Cities>().HasKey(u => u.Id);
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



        }
    }
}
